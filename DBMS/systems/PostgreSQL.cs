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

        /*public PostgreSQL(string conn_string) : base(conn_string)
        {
        }*/

        public override string ConnectionString() =>
            string.Join(";",
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
                        }.Select(o => $"-c {o}")));


        public override IDbConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
            return new NpgsqlConnection(ConnectionString());
        }

        public override Compiler GetCompiler() => new PostgresCompiler();

        public override void CopyText<T>(Action<TextWriter> addData) =>
            CopyText(typeof(T).Name.ToSnakeCase(), ColumnNames<T>(), addData);


        public override void CopyText(string table_name, string[] cols, Action<TextWriter> addData)
        {
            var sql = string.Format("COPY {0}.{1} ({2}) FROM STDIN", schema.SchemaName, table_name,
                                    string.Join(", ", cols));
            using (var conn = (NpgsqlConnection) GetConnection())
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

        public override void CopyBinaryRows(string table_name, string[] cols, Action<Action, Action<object>> addData) =>
            CopyBinary(table_name, cols, writer =>
            {
                addData(
                    () => writer.StartRow(),             //For starting new row
                    value => writer.PgBinaryWrite(value) //For adding data to row
                );
            });

        public override void CopyBinary(string table_name, string[] cols, Action<NpgsqlBinaryImporter> addData)
        {
            var sql = string.Format("COPY {0}.{1} ({2}) FROM STDIN (FORMAT BINARY)", schema.SchemaName, table_name,
                                    string.Join(", ", cols));
            Log.Info($"Start SQL: {sql}");
            using (var conn = (NpgsqlConnection) GetConnection())
            {
                conn.Open();
                using (var writer = conn.BeginBinaryImport(sql))
                {
                    addData(writer);
                    writer.Complete();
                    Log.Info($"Complete SQL: {sql}");
                }
            }
        }

        public override void BinaryCopy(DBMSSystem toSchema, string fromQuery, string toQuery)
        {
            using (var f_conn = (NpgsqlConnection) GetConnection())
            {
                f_conn.Open();
                using (var t_conn = (NpgsqlConnection) toSchema.GetConnection())
                {
                    t_conn.Open();
                    using (var inStream = f_conn.BeginRawBinaryCopy(fromQuery))
                    using (var outStream = t_conn.BeginRawBinaryCopy(toQuery))
                    {
                        inStream.CopyTo(outStream);
                    }
                }
            }
        }

        public static void PgBinaryRow(NpgsqlBinaryImporter writer, Action<Action<object>> cell)
        {
            writer.StartRow();
            cell(writer.PgBinaryWrite);
        }

        public static NpgsqlDbType? PgTypeCoerce(object value)
        {
            switch (value)
            {
                case bool _:
                    return NpgsqlDbType.Boolean;
                case byte _:
                case sbyte _:
                    return NpgsqlDbType.Smallint;
                case short _:
                case int _:
                    return NpgsqlDbType.Integer;
                case long _:
                    return NpgsqlDbType.Bigint;
                case float _:
                    return NpgsqlDbType.Real;
                case double _:
                    return NpgsqlDbType.Double;
                case decimal _:
                case BigInteger _:
                    return NpgsqlDbType.Numeric;
                case string _:
                case char[] _:
                case char _:
                    return NpgsqlDbType.Text;
                case Guid _:
                    return NpgsqlDbType.Uuid;
                case byte[] _:
                    return NpgsqlDbType.Bytea;
                case DateTime _:
                    return NpgsqlDbType.Timestamp;
                case TimeSpan _:
                    return NpgsqlDbType.Interval;
                case IPAddress _:
                    return NpgsqlDbType.Inet;
                case PhysicalAddress _:
                    return NpgsqlDbType.MacAddr;
                case NpgsqlTsQuery _:
                    return NpgsqlDbType.TsQuery;
                case NpgsqlTsVector _:
                    return NpgsqlDbType.TsVector;
                case BitArray _:
                    return NpgsqlDbType.Varbit;
                case IDictionary<string, string> _:
                    return NpgsqlDbType.Hstore;
                default:
                    return null;
            }
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

            var t = PostgreSQL.PgTypeCoerce(value);
            if (null == t) writer.Write(value);
            else writer.Write(value, (NpgsqlDbType) t);
        }
    }
}