using DBMS;
using DBMS.systems;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    public abstract class FullLoader<T, C> : Loader<T, C> where T : new()
    {
        public FullLoader(string table_name) : base(DB.Source, table_name) { }
        public FullLoader(DBMSSystem db, string table_name) : base(db, table_name) { }

        public abstract void ChunkData();

        public void CustomizeQuery(Query query, string schema_name)
        {
            switch (table_name)
            {
                case "lookup":
                    query.SelectRaw("lookuptype.name, lookup.*").Join($"{schema_name}.lookuptype", "lookup.lookup_type_id", "lookuptype.lookup_type_id");
                    break;
                case "source_to_standard":
                    query.Where("target_standard_concept", "S").WhereNull("target_invalid_reason");
                    break;
            }
        }

        protected void AddChunkByKeys(C item,params string[] keys)
        {
            //Skip if all chunk variables are null or no key shared
            if (keys.Length <= 0 || keys.Where(k => null != k).Count() == 0) return;
            multiChunks.AddValue(item, CKeys(keys));
        }

        protected void AddChunkByKey(C item, string key)
        {
            if (!chunks.ContainsKey(key)) chunks[key] = new List<C> { item };
            else chunks[key].Add(item);
        }

        protected static C ChunkItem(string key) => ChunkItem(new string[] { key });
        protected static C ChunkItem(IEnumerable<string> keys) => ChunkItem(keys.ToArray());

        protected static C ChunkItem(string[] keys)
        {
            var me = ((FullLoader<T, C>)(object)GetMe());
            var res = keys.Where(k => me.chunks.ContainsKey(k)).Select(k => me.chunks[k].First());
            return res.Count() > 0 ? res.First() : default;
        }
        protected static C ChunkValue(params string[] keys) => ChunkValue(new string[][] { keys });
        protected static C ChunkValue(IEnumerable<string[]> keys) => ChunkValue(keys.ToArray());
        protected static C ChunkValue(string[][] keys) => ((FullLoader<T, C>)(object)GetMe()).IChunkValue(keys);

        private C IChunkValue(string[][] keys)
        {
            C value;
            foreach (var iKeys in keys)
            {
                if (iKeys.Length <= 0 || iKeys.Where(k => !string.IsNullOrEmpty(k)).Count() == 0) continue;
                if (null != (value = multiChunks.FirstValue<string, C>(CKeys(iKeys,true)))) return value;
            }
            return default;
        }

        protected void ParallelChunk(List<Action<C>> actions)
        {
            if (actions == null || 0 >= actions.Count)
            {
                Log.Info($"No Data Chunk Actions For #{typeof(T).Name}");
                return;
            }
            Log.Info($"Starting Data Chunk #{typeof(T).Name}");
            Log.Info($"DataChunk Stats: Total Data to Chunk: #{data.Count} [{typeof(T).Name}]");
            Parallel.ForEach(data, dt =>
            {
                Parallel.ForEach(actions, x => x(dt));
            });
            Log.Info($"DataChunk Stats: Total Lvl 1 Chunks: #{multiChunks.Count} [{typeof(T).Name}]");
            Log.Info($"Finished Data Chunk #{typeof(T).Name}");
        }

        public static void Initialize()
        {
            GetMe();
        }

        private string[] CKeys(string[] keys,bool forVal=false)
        {
            return  ((2 > keys.Length) && !forVal ? keys = CKeys(new string[] { ChunkPrefixKey, keys[0] }) : keys).Select(k => k ?? ChunkPrefixKey).ToArray();
        }
    }
}
