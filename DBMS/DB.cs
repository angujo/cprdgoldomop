using System;
using DBMS.systems;
using System.Collections.Concurrent;
using System.Linq;
using DBMS.models;
using Util;

namespace DBMS
{
    public static class DB
    {
        static ConcurrentDictionary<string, DBMSSystem> holder = new ConcurrentDictionary<string, DBMSSystem>();

        public static int VALUE_ROWS => 500; // Modify later for custom

        public static DBMSSystem Target => GetSchema(SchemaType.TARGET);

        public static DBMSSystem Source => GetSchema(SchemaType.SOURCE);

        public static DBMSSystem Vocabulary => GetSchema(SchemaType.VOCABULARY);

        public static DBMSSystem Internal => GetSchema(SchemaType.INTERNAL);

        private static DBMSSystem GetSchema(SchemaType sType)
        {
            if (holder.ContainsKey(sType.GetStringValue())) return holder[sType.GetStringValue()];
            string conn_string;
            string schema_name;
            switch (sType)
            {
                case SchemaType.TARGET:
                    conn_string = Setting.TargetConnection;
                    schema_name = Setting.TargetSchema;
                    break;
                case SchemaType.SOURCE:
                    conn_string = Setting.SourceConnection;
                    schema_name = Setting.SourceSchema;
                    break;
                case SchemaType.INTERNAL:
                    conn_string = Setting.AppConnection;
                    schema_name = Setting.AppSchema;
                    break;
                case SchemaType.VOCABULARY:
                default:
                    conn_string = Setting.VocabConnection;
                    schema_name = Setting.VocabSchema;
                    break;
            }

            return holder[sType.GetStringValue()] = GetOne(conn_string, schema_name);
        }

        public static void FetchSchemas(long workloadId)
        {
            SchemaType[] cleanable = {SchemaType.SOURCE, SchemaType.TARGET, SchemaType.VOCABULARY};
            Internal.GetAll<Dbschema>("WHERE workloadid = @wlid", new {wlid = workloadId})
                    .Where(sc => cleanable.Select(t => t.GetStringValue()).Contains(sc.schematype))
                    .ToList()
                    .ForEach(sc => { holder[sc.schematype] = FromDbSchema(sc); });
            if (holder.Count < (cleanable.Length + 1)) throw new Exception("Unable to load schemas for the workload!");
        }

        public static DBMSSystem FromDbSchema(Dbschema dbschema)
        {
            return GetOne(new DBSchema()
            {
                Password   = EncryptionHelper.Decrypt(dbschema.password),
                Port       = dbschema.port,
                Schematype = dbschema.schematype,
                Server     = dbschema.server,
                Username   = dbschema.username,
                SchemaName = dbschema.schemaname,
                DBName     = dbschema.dbname,
            });
        }

        private static DBMSSystem GetOne(DBSchema schema) => new PostgreSQL(schema);

        private static DBMSSystem GetOne(string conn_string, string schema_name)
        {
            //Switch depending on DBMS System
            return new PostgreSQL(conn_string) {schema = new DBSchema {SchemaName = schema_name,}};
        }
    }

    public static class FileQueryHelper
    {
        const string PH_SC_SOURCE = @"{ss}";
        const string PH_SC_TARGET = @"{sc}";
        const string PH_SC_VOCAB  = @"{vs}";

        public static string RemovePlaceholders(this string content, params string[][] phs)
        {
            foreach (var p in phs)
            {
                if (2 != p.Length) continue;
                content = content.Replace(p[0], p[1]);
            }

            return content
                   .Replace(PH_SC_VOCAB, DB.Vocabulary.schema.SchemaName)
                   .Replace(PH_SC_TARGET, DB.Target.schema.SchemaName)
                   .Replace(PH_SC_SOURCE, DB.Source.schema.SchemaName)
                   .Replace(PH_SC_VOCAB.ToUpper(), DB.Vocabulary.schema.SchemaName)
                   .Replace(PH_SC_TARGET.ToUpper(), DB.Target.schema.SchemaName)
                   .Replace(PH_SC_SOURCE.ToUpper(), DB.Source.schema.SchemaName);
        }
    }

    public enum SchemaType
    {
        [StringValue("target")]     TARGET,
        [StringValue("source")]     SOURCE,
        [StringValue("vocabulary")] VOCABULARY,
        [StringValue("internal")]   INTERNAL
    }
}