using Npgsql;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlKata.Compilers;
using System.Data;
using Dapper;

namespace DBMS.systems
{
    public class PostgreSQL : DBMSSystem
    {
        public PostgreSQL(DBSchema schema) : base(schema) { }

        public PostgreSQL(string conn_string) : base(conn_string) { }

        public override string ConnectionString()
        {
            return string.IsNullOrEmpty(conn_string) ?
                String.Join(";", new string[] {
                @"Server="+ schema.Server,
                @"Port="+ schema.Port,
                @"User Id="+ schema.Username,
                @"Password="+ schema.Password,
                @"Database="+ schema.DBName,
                @"ApplicationName=OMOPBuilder",
                @"Pooling=false",
                @"IncludeErrorDetail=true",
                @"CommandTimeout=36000",
                @"Options="+String.Join(" ", (new string[] {
                    "synchronous_commit=off"
                }).Select(o=>$"-c {o}"))
            }) : conn_string;
        }

        public override IDbConnection GetConnection()
        {
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
            return new NpgsqlConnection(ConnectionString());
        }

        public override Compiler GetCompiler()
        {
            return new PostgresCompiler();
        }

        public void BinaryCopy(DBMSSystem toSchema, string fromQuery, string toQuery)
        {
            using (NpgsqlConnection f_conn = (NpgsqlConnection)GetConnection())
            {
                f_conn.Open();
                using (NpgsqlConnection t_conn = (NpgsqlConnection)toSchema.GetConnection())
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
    }
}
