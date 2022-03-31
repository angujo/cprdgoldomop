﻿using Dapper;
using DBMS.models;
using Npgsql;
using NpgsqlTypes;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DBMS.systems
{
    public abstract class DBMSSystem : IDBMSSystem
    {
        public DBSchema schema { get; set; }
        protected string conn_string { get; set; }

        ConcurrentDictionary<string, PropertyInfo[]> columns = new ConcurrentDictionary<string, PropertyInfo[]>();

        protected DBMSSystem()
        {
            var resolver = new SimpleCRUDResolver();
            SimpleCRUD.SetColumnNameResolver(resolver);
            SimpleCRUD.SetTableNameResolver(resolver);
        }

        public DBMSSystem(DBSchema schema) : this() { this.schema = schema; }
        public DBMSSystem(string conn_string) : this() { this.conn_string = conn_string; }

        public abstract string ConnectionString();

        public abstract void BinaryCopy(DBMSSystem toSchema, string fromQuery, string toQuery);
        public abstract void CopyText<T>(Action<TextWriter> addData);
        public abstract void CopyText(string table_name, string[] cols, Action<TextWriter> addData);
        public abstract void CopyBinary<T>(Action<NpgsqlBinaryImporter> addData);
        public abstract void CopyBinary(string table_name, string[] cols, Action<NpgsqlBinaryImporter> addData);
        public abstract void CopyBinaryRows(string table_name, string[] cols, Action<Action, Action<object>> addData);


        public abstract Compiler GetCompiler();
        public abstract IDbConnection GetConnection();

        public QueryFactory QueryFactory()
        {
            return new QueryFactory(this.GetConnection(), this.GetCompiler());
        }

        public void RunFactory(string table_name, Action<Query, string> action)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                action(new QueryFactory(conn, GetCompiler()).Query(Dot(schema.SchemaName, table_name)), schema.SchemaName);
            }
        }

        public void RunFactory(Chunk chunk, Action<Query, string> action)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var query = new QueryFactory(conn, GetCompiler()).Query(string.Join(".", new string[] { DB.Source.schema.SchemaName, chunk.tableName, }));
                query.Join(Dot(schema.SchemaName, chunk.relationTableName), Dot(chunk.relationTableName, chunk.relationColumn), Dot(chunk.tableName, chunk.column))
                    .SelectRaw(Dot(chunk.relationTableName, "*"))
                    .Where(Dot(chunk.tableName, chunk.ordinalColumn), chunk.ordinal);
                action(query, schema.SchemaName);
            }
        }

        public int RunQuery(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    return cmd.ExecuteNonQuery();
                }
                // return new QueryFactory(conn, GetCompiler()).Statement(query);
            }
        }

        public void RunConnection(Action<IDbConnection> action)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                action(conn);
            }
        }

        private string Dot(string schema, string table)
        {
            return string.Join(".", new string[] { schema, table });
        }

        public T Load<T>(object args)
        {
            if (args.IsNumber())
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return conn.Get<T>(args);
                }
            }
            return QueryFactory().Query(typeof(T).Name.ToLower()).Where(args).First<T>();
        }

        public int Update<T>(T obj, object where)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return new QueryFactory(conn, GetCompiler()).Query(Dot(schema.SchemaName, typeof(T).Name.ToLower())).Where(where).Update(ColumnValues(obj));
            }
        }

        public long Insert<T>(T obj)
        {
            return Insert(typeof(T).Name, ColumnValues<T>(obj).Where(cv => null != cv.Value));
        }

        public long Insert(string table_name, IEnumerable<KeyValuePair<string, object>> values)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return new QueryFactory(conn, GetCompiler()).Query(Dot(schema.SchemaName, table_name.ToLower())).InsertGetId<long>(values);
            }
        }

        public long Insert<T>(object[][] values)
        {
            return Insert<T>(typeof(T).Name, values);
        }

        public long Insert<T>(string tbl_name, object[][] values)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return new QueryFactory(conn, GetCompiler()).Query(Dot(schema.SchemaName, tbl_name.ToLower())).Insert(ColumnNames<T>(), values);
            }
        }

        private PropertyInfo[] GetColumns<T>(T obj = default)
        {
            string tkey = typeof(T).Name;
            if (columns.ContainsKey(tkey)) return columns[tkey];
            return columns[tkey] = typeof(T).GetProperties()
                           .Where(pi =>
                           {
                               if ("id" == pi.Name.ToLower()) return false;
                               var attrs = pi.GetCustomAttributes(true);
                               if (attrs == null || attrs.Length <= 0) return true;
                               object ea;
                               if (null == (ea = attrs.FirstOrDefault(a => a is SaveableAttribute || a is EditableAttribute))) return true;
                               return (ea is SaveableAttribute sa && sa.AllowSave) || (ea is EditableAttribute da && da.AllowEdit);
                           }).ToArray();
        }

        public string[] ColumnNames<T>(T obj = default) => GetColumns<T>(obj).Select(p => p.Name.ToLower()).ToArray();

        public object[] ColumnValues<T>(object obj) => GetColumns<T>().Select(p => p.GetValue(obj, null)).ToArray();

        public Dictionary<string, object> ColumnValues<T>(T obj) => GetColumns<T>(obj).ToDictionary(p => p.Name.ToLower(), p => p.GetValue(obj, null));

        public IEnumerable<T> GetAll<T>(object args)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return conn.GetList<T>(args);
            }
        }

        public IEnumerable<T> GetAll<T>(string stmt, object args = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return conn.GetList<T>(stmt, args ?? new { });
            }
        }

        public static void PgBinaryRow(NpgsqlBinaryImporter writer, Action<Action<object>> cell)
        {
            writer.StartRow();
            cell(val =>
            {
                writer.PgBinaryWrite(val);
            });
        }

        public static NpgsqlDbType? PgTypeCoherse(object value)
        {
            if (value is bool) return NpgsqlDbType.Boolean;
            if (value is byte || value is sbyte) return NpgsqlDbType.Smallint;
            if (value is short || value is int) return NpgsqlDbType.Integer;
            if (value is long) return NpgsqlDbType.Bigint;
            if (value is float) return NpgsqlDbType.Real;
            if (value is double) return NpgsqlDbType.Double;
            if (value is decimal || value is BigInteger) return NpgsqlDbType.Numeric;
            if (value is string || value is char[] || value is char) return NpgsqlDbType.Text;
            if (value is Guid) return NpgsqlDbType.Uuid;
            if (value is byte[]) return NpgsqlDbType.Bytea;
            if (value is DateTime) return NpgsqlDbType.Timestamp;
            if (value is TimeSpan) return NpgsqlDbType.Interval;
            if (value is IPAddress) return NpgsqlDbType.Inet;
            if (value is PhysicalAddress) return NpgsqlDbType.MacAddr;
            if (value is NpgsqlTsQuery) return NpgsqlDbType.TsQuery;
            if (value is NpgsqlTsVector) return NpgsqlDbType.TsVector;
            if (value is BitArray) return NpgsqlDbType.Varbit;
            if (value is IDictionary<string, string>) return NpgsqlDbType.Hstore;
            return null;
        }
    }

    public static class DBExtend
    {
        public static void PgBinaryWrite(this NpgsqlBinaryImporter writer, object value)
        {
            var t = DBMSSystem.PgTypeCoherse(value);
            if (null == t) writer.Write(value);
            else writer.Write(value, (NpgsqlDbType)t);
        }
    }
}
