using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlKata.Compilers;
using System.Data;
using Dapper;
using System.IO;
using Util;
using NpgsqlTypes;
using System.Numerics;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections;

namespace DBMS.systems
{
    public class PostgreSQL : DBMSSystem
    {
        public PostgreSQL(DBSchema schema) : base(schema)
        {
        }

        public PostgreSQL(string conn_string) : base(conn_string)
        {
        }

        public override string ConnectionString()
        {
            if (string.IsNullOrEmpty(conn_string))
            {
                var str = conn_string;
            }
            return string.IsNullOrEmpty(conn_string)
                ? string.Join(";",
                              @"Server=" + schema.Server,
                              @"Port=" + schema.Port,
                              @"User Id=" + schema.Username,
                              @"Password=" + schema.Password,
                              @"Database=" + schema.DBName,
                              @"ApplicationName=OMOPBuilder",
                              @"Pooling=false",
                              @"IncludeErrorDetail=true",
                              @"CommandTimeout=36000",
                              @"Options=" + string.Join(" ", new[]
                              {
                                  "synchronous_commit=off"
                              }.Select(o => $"-c {o}")))
                : conn_string;
        }

        public override IDbConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
            // Log.Info(ConnectionString());
            return new NpgsqlConnection(ConnectionString());
        }

        public override Compiler GetCompiler()
        {
            return new PostgresCompiler();
        }

        public override void CopyText<T>(Action<TextWriter> addData)
        {
            CopyText(typeof(T).Name.ToSnakeCase(), ColumnNames<T>(), addData);
        }

        public override void CopyText(string table_name, string[] cols, Action<TextWriter> addData)
        {
            string sql = string.Format("COPY {0}.{1} ({2}) FROM STDIN", schema.SchemaName, table_name,
                                       string.Join(", ", cols));
            using (NpgsqlConnection conn = (NpgsqlConnection) GetConnection())
            {
                conn.Open();
                using (var writer = conn.BeginTextImport(sql))
                {
                    addData(writer);
                    writer.Flush();
                }
            }
        }

        public override void CopyBinary<T>(Action<NpgsqlBinaryImporter> addData) =>
            CopyBinary(typeof(T).Name.ToSnakeCase(), ColumnNames<T>(), addData);

        public override void CopyBinaryRows<T>(string[] cols, Action<Action, Action<object>> addData) =>
            CopyBinaryRows(typeof(T).Name.ToSnakeCase(), cols, addData);

        public override void CopyBinaryRows(string table_name, string[] cols, Action<Action, Action<object>> addData)
        {
            CopyBinary(table_name, cols, writer =>
            {
                addData(
                    () => writer.StartRow(),             //For starting new row
                    value => writer.PgBinaryWrite(value) //For adding data to row
                );
            });
        }

        public override void CopyBinary(string table_name, string[] cols, Action<NpgsqlBinaryImporter> addData)
        {
            string sql = string.Format("COPY {0}.{1} ({2}) FROM STDIN (FORMAT BINARY)", schema.SchemaName, table_name,
                                       string.Join(", ", cols));
            Log.Info($"Start SQL: {sql}");
            using (NpgsqlConnection conn = (NpgsqlConnection) GetConnection())
            {
                conn.Open();
                using (NpgsqlBinaryImporter writer = conn.BeginBinaryImport(sql))
                {
                    addData(writer);
                    writer.Complete();
                    Log.Info($"Complete SQL: {sql}");
                }
            }
        }

        public override void BinaryCopy(DBMSSystem toSchema, string fromQuery, string toQuery)
        {
            using (NpgsqlConnection f_conn = (NpgsqlConnection) GetConnection())
            {
                f_conn.Open();
                using (NpgsqlConnection t_conn = (NpgsqlConnection) toSchema.GetConnection())
                {
                    t_conn.Open();
                    using (NpgsqlRawCopyStream inStream = f_conn.BeginRawBinaryCopy(fromQuery))
                    using (NpgsqlRawCopyStream outStream = t_conn.BeginRawBinaryCopy(toQuery))
                    {
                        inStream.CopyTo(outStream);
                    }
                }
            }
        }

        public static void PgBinaryRow(NpgsqlBinaryImporter writer, Action<Action<object>> cell)
        {
            writer.StartRow();
            cell(val => { writer.PgBinaryWrite(val); });
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

    internal static class PGExtend
    {
        public static void PgBinaryWrite(this NpgsqlBinaryImporter writer, object value)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var t = PostgreSQL.PgTypeCoherse(value);
            if (null == t) writer.Write(value);
            else writer.Write(value, (NpgsqlDbType) t);
        }
    }
}