using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DBMS.systems
{
    public abstract class DBMSSystem : IDBMSSystem
    {
        public DBSchema schema;
        QueryFactory qf;
        public DBMSSystem(DBSchema schema) { this.schema = schema; }

        public abstract string ConnectionString();
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
                DBMSSystem db = (DBMSSystem)chunk.dbms;
                var query = new QueryFactory(conn, GetCompiler()).Query(string.Join(".", new string[] { db.schema.SchemaName, chunk.tableName, }));
                query.Join(Dot(schema.SchemaName, chunk.relationTableName), Dot(chunk.relationTableName, chunk.relationColumn), Dot(chunk.tableName, chunk.column))
                    .SelectRaw(Dot(chunk.relationTableName, "*"))
                    .Where(Dot(chunk.tableName, chunk.ordinalColumn), chunk.ordinal);
                action(query, schema.SchemaName);
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
    }
}
