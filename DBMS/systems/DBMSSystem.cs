using Dapper;
using DBMS.models;
using Npgsql;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public abstract void CopyBinaryRows<T>(string[] cols, Action<Action, Action<object>> addData);


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

        public void RunFactory(Action<QueryFactory> action)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                action(new QueryFactory(conn, GetCompiler()));
            }
        }

        public void RunChunk(Chunk chunk, string tbl_name, Action<Query, string> action)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var query = new QueryFactory(conn, GetCompiler()).Query(string.Join(".", new string[] { DB.Source.schema.SchemaName, chunk.tableName, }));
                query.Join(Dot(schema.SchemaName, tbl_name), Dot(tbl_name, chunk.relationColumn), Dot(chunk.tableName, chunk.column))
                    .SelectRaw(Dot(tbl_name, "*"))
                    .SelectRaw(Dot(chunk.tableName, "id as chunk_id"))
                    .Where(Dot(chunk.tableName, chunk.ordinalColumn), chunk.ordinal);
                action(query, schema.SchemaName);
            }
        }

        // For parameters use $1, $2, ... $N for placeholders with args holding value with resp to order
        public int RunQuery(string query, params object[] args)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        foreach (var arg in args) cmd.Parameters.Add(arg);
                        return cmd.ExecuteNonQuery();
                    }
                    // return new QueryFactory(conn, GetCompiler()).Statement(query);
                }
            }
            catch (Exception)
            {
                Log.Error(query);
                throw;
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
            return QueryFactory().Query(typeof(T).Name.ToSnakeCase()).Where(args).FirstOrDefault<T>();
        }

        public int Update<T>(T obj, object where)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return new QueryFactory(conn, GetCompiler()).Query(Dot(schema.SchemaName, typeof(T).Name.ToSnakeCase())).Where(where).Update(ColumnValues(obj));
            }
        }

        public long Insert<T>(T obj) => Insert(typeof(T).Name.ToSnakeCase(), ColumnValues<T>(obj).Where(cv => null != cv.Value));

        public long Insert(string table_name, IEnumerable<KeyValuePair<string, object>> values)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return new QueryFactory(conn, GetCompiler()).Query(Dot(schema.SchemaName, table_name.ToLower())).InsertGetId<long>(values);
            }
        }

        public long InsertPlain<T>(T obj) => InsertPlain(typeof(T).Name.ToSnakeCase(), ColumnValues<T>(obj).Where(cv => null != cv.Value));

        public long InsertPlain(string table_name, IEnumerable<KeyValuePair<string, object>> values)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return new QueryFactory(conn, GetCompiler()).Query(Dot(schema.SchemaName, table_name.ToSnakeCase())).Insert(values);
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
                return new QueryFactory(conn, GetCompiler()).Query(Dot(schema.SchemaName, tbl_name.ToSnakeCase())).Insert(ColumnNames<T>(), values);
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
    }
}
