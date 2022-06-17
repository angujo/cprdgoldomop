using System;
using DBMS.systems;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (!sType.Equals(SchemaType.INTERNAL)) throw new Exception("Schemas need to be fetched and loaded!");

            return holder[sType.GetStringValue()] = GetOne(ToDBSchema(Setting.AppConnection, Setting.AppSchema));
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

        /*private static DBMSSystem GetOne(string conn_string, string schema_name)
        {
            //Switch depending on DBMS System
            return new PostgreSQL(conn_string) {schema = new DBSchema {SchemaName = schema_name,}};
        }*/

        public static DBSchema ToDBSchema(string conn_str, string name, SchemaType type = SchemaType.INTERNAL)
        {
            // var conn_str="AuthType=AD;Url=http://crm.xxx.com/CRM365; Domain='test'; Username=&quotetestuser&quote; Password='T,jL4O&amp;vc%t;30'";
            //=localhost;=5432;=postgres;=postgres;=omopapp;
            var new_conn  = conn_str;
            var regexes   = new[] {@"(\$\d+)", @"("")(.*?)("")", @"(')(.*?)(')", @"(&quote)(.*?)(&quote)",};
            var escHolder = new Dictionary<int, string>();
            foreach (var regStr in regexes)
            {
                var qRegex = new Regex(regStr, RegexOptions.IgnoreCase);
                var match  = qRegex.Match(conn_str??"");
                Console.WriteLine(regStr + $": {match.Groups.Count}");
                if (!match.Success) continue;
                foreach (var g in match.Groups) Console.WriteLine($"\t:gg {g}");
                var grCount = match.Groups.Count;
                do
                {
                    var i = escHolder.Count;
                    var c = grCount <= 1 ? 0 : (int) Math.Floor((double) grCount / 2);

                    var str = match.Groups[c].ToString();
                    Console.WriteLine(match.Groups[1]);
                    escHolder.Add(i, str);
                    new_conn = new_conn.Replace(match.Groups[0].ToString(), $"${i}");
                } while ((match = match.NextMatch()).Success);
            }

            var parts    = new_conn.Split(';');
            var dbSchema = new DBSchema();
            foreach (var part in parts)
            {
                var entries = part.Split('=');
                if (entries.Length != 2) continue;
                var value = entries[1];
                // Console.WriteLine(part+$": {entries.Length} ({entries[0]}, {val})");
                var rInt = new Regex(@"^(\s+)?\$(\d+)(\s+)?$").Match(value);
                if (rInt.Success && int.TryParse(rInt.Groups[2].ToString(), out var i) && escHolder.ContainsKey(i))
                    value = escHolder[i];

                switch (entries[0].ToLower())
                {
                    case "datas source":
                    case "address":
                    case "addr":
                    case "network address": break;
                    case "host":
                    case "server":
                        dbSchema.Server = value;
                        break;
                    case "port":
                        dbSchema.Port = int.Parse(value);
                        break;
                    case "user":
                    case "uid":
                    case "user id":
                        dbSchema.Username = value;
                        break;
                    case "pwd":
                    case "password":
                        dbSchema.Password = value;
                        break;
                    case "initial catalog":
                    case "database":
                        dbSchema.DBName = value;
                        break;
                }
            }

            dbSchema.Schematype = type.GetStringValue();
            dbSchema.SchemaName = name;

            return dbSchema;
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