using Npgsql;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlKata.Compilers;
using System.Data;

namespace DBMS.systems
{
    public class PostgreSQL : DBMSSystem
    {
        public PostgreSQL(DBSchema schema) : base(schema) { }

        public override string ConnectionString()
        {
            return String.Join(";", new string[] {
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
            });
        }

        public override IDbConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString());
        }

        public override Compiler GetCompiler()
        {
            return new PostgresCompiler();
        }
    }
}
