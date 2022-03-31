using DBMS.systems;
using System.Collections.Concurrent;
using Util;

namespace DBMS
{
    public static class DB
    {
        static ConcurrentDictionary<string, DBMSSystem> holder = new ConcurrentDictionary<string, DBMSSystem>();

        public static int VALUE_ROWS { get { return 500; } }// Modify later for custom
        public static DBMSSystem Target { get { return GetSchema(SchemaType.TARGET); } }
        public static DBMSSystem Source { get { return GetSchema(SchemaType.SOURCE); } }
        public static DBMSSystem Vocabulary { get { return GetSchema(SchemaType.VOCABULARY); } }
        public static DBMSSystem Internal { get { return GetSchema(SchemaType.INTERNAL); } }

        private static DBMSSystem GetSchema(SchemaType sType)
        {
            if (holder.ContainsKey(sType.GetStringValue())) return holder[sType.GetStringValue()];
            string conn_string;
            string schema_name;
            switch (sType)
            {
                case SchemaType.TARGET: conn_string = Setting.TargetConnection; schema_name = Setting.TargetSchema; break;
                case SchemaType.SOURCE: conn_string = Setting.SourceConnection; schema_name = Setting.SourceSchema; break;
                case SchemaType.INTERNAL: conn_string = Setting.AppConnection; schema_name = Setting.AppSchema; break;
                case SchemaType.VOCABULARY:
                default: conn_string = Setting.VocabConnection; schema_name = Setting.VocabSchema; break;
            }
            var sch = new DBSchema
            {
                SchemaName = schema_name,
            };
            //Switch depending on DBMS System
            return holder[sType.GetStringValue()] = new PostgreSQL(conn_string) { schema = sch };
        }
    }

    public static class FileQueryHelper
    {
        const string PH_SC_SOURCE = @"{ss}";
        const string PH_SC_TARGET = @"{sc}";
        const string PH_SC_VOCAB = @"{vs}";

        public static string RemovePlaceholders(this string content, params string[][] phs)
        {
            foreach (var p in phs)
            {
                if (2 != p.Length) continue;
                content = content.Replace(p[0], p[1]);
            }
            return content.Replace(PH_SC_VOCAB, DB.Vocabulary.schema.SchemaName)
                .Replace(PH_SC_TARGET, DB.Target.schema.SchemaName)
                .Replace(PH_SC_SOURCE, DB.Source.schema.SchemaName);
        }
    }

    internal enum SchemaType
    {
        [StringValue("target")]
        TARGET,
        [StringValue("source")]
        SOURCE,
        [StringValue("vocabulary")]
        VOCABULARY,
        [StringValue("internal")]
        INTERNAL
    }
}
