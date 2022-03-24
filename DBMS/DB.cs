using DBMS.systems;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace DBMS
{
    public static class DB
    {
        static ConcurrentDictionary<string, DBMSSystem> holder = new ConcurrentDictionary<string, DBMSSystem>();

        public static int VALUE_ROWS { get { return 200; } }// Modify later for custom
        public static DBMSSystem Target { get { return GetSchema(SchemaType.TARGET); } }
        public static DBMSSystem Source { get { return GetSchema(SchemaType.SOURCE); } }
        public static DBMSSystem Vocabulary { get { return GetSchema(SchemaType.VOCABULARY); } }

        private static DBMSSystem GetSchema(SchemaType sType)
        {
            if (holder.ContainsKey(sType.GetStringValue())) return holder[sType.GetStringValue()];
            string sname;
            switch (sType)
            {
                case SchemaType.TARGET: sname = "target"; break;
                case SchemaType.SOURCE: sname = "source"; break;
                case SchemaType.VOCABULARY:
                default: sname = "vocabulary"; break;
            }
            var sch = new DBSchema
            {
                DBName = "cdmapp",
                Port = 5432,
                SchemaName = sname,
                Password = "postgres",
                Server = "localhost",
                Username = "postgres",
            };
            //Switch depending on DBMS System
            return holder[sType.GetStringValue()] = new PostgreSQL(sch);
        }
    }

    public class iDBMS
    {
        public QueryFactory DB;
        public Compiler CP;
    }

    internal enum SchemaType
    {
        [StringValue("target")]
        TARGET,
        [StringValue("source")]
        SOURCE,
        [StringValue("vocabulary")]
        VOCABULARY
    }
}
