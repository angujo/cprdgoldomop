using DBMS;
using Npgsql;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.mappers
{
    internal abstract class Mapper<T> : ADataLoader<T> where T : new()
    {
        protected Chunk chunk;

        public static void InsertSets()
        {
            Log.Info($"Data Load started for {typeof(T).Name}. ");
            var data = ((Mapper<T>)(object)GetMe()).data;
            var table_name = typeof(T).Name.ToSnakeCase();
            Log.Info($"Data Loaded. Preparing inserts for {table_name}. ");
            Log.Info($"Total Data [{table_name}] {data.Count} ");
            List<object[]> values = new List<object[]>();
            PropertyInfo[] props = typeof(T).GetProperties();
            var db = DB.Target;
            Action insert = () =>
            {
                var cols = props.Select(p => p.Name).ToArray();
                var vals = values.ToArray();
                db.RunFactory(table_name, (query, sch) =>
                {
                    query.Insert(cols, vals);
                });

                values.Clear();
            };
            Log.Info($"Starting inserts for {table_name}. ");

            foreach (var set in data)
            {
                var row = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    row[i] = props[i].GetValue(set, null);
                }
                values.Add(row);
                if (DB.VALUE_ROWS == values.Count) insert();
            }

            if (0 < values.Count) insert();
            Log.Info($"Finished inserts for {table_name}. ");
        }
    }
}
