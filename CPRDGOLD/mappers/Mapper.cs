using DBMS;
using DBMS.models;
using System.Collections.Generic;
using Util;

namespace CPRDGOLD.mappers
{
    internal abstract class Mapper<T> : ADataLoader<T> where T : new()
    {
        protected Chunk chunk;
        protected string Delimiter = "\t";

        public static void InsertSets(Chunk chunk)
        {
            var _me = new T();
            var me = (Mapper<T>)(object)_me;
            if (null != chunk)
            {
                me.chunk = chunk;
                me.chunk.AddCleaner(() => me.Clean());
            }
            Log.Info($"Starting Data Load [{typeof(T).Name}]");
            if (null != me.GetType().GetMethod("QueryInsert")) me.GetType().GetMethod("QueryInsert").Invoke(me, null);
            else me.LoadData();
            Log.Info($"Finished Data Load [{typeof(T).Name}]");

            var table_name = typeof(T).Name.ToSnakeCase();
            Log.Info($"Data Load started for {typeof(T).Name}. ");
            //We are doing binary import
            //Ignore below unless otherwise
            /*
            var data = me.data;
            Log.Info($"Data Loaded. Preparing inserts for {table_name}. ");
            Log.Info($"Total Data [{table_name}] {data.Count} ");
            List<object[]> values = new List<object[]>();

            void insert()
            {
                Log.Info($"Progress inserts for {table_name}. #{typeof(T).Name}");
                DB.Target.Insert<T>(table_name, values.ToArray());

                values.Clear();
            }
            Log.Info($"Starting inserts for {table_name}. #{typeof(T).Name}");

            foreach (var set in data)
            {
                values.Add(DB.Target.ColumnNames<T>(set));
                if (DB.VALUE_ROWS == values.Count) insert();
            }

            if (0 < values.Count) insert();
            */
            Log.Info($"Finished inserts for {table_name}. #{typeof(T).Name}");
            if (null != me.GetType().GetMethod("Dependency")) me.GetType().GetMethod("Dependency").Invoke(me, null);
        }
    }
}
