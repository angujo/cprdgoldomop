using DBMS;
using DBMS.systems;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    public abstract class Loader<T, C> where T : new()
    {
        private string prefix_key;
        protected List<C> data = new List<C>();
        protected Dictionary<string, List<C>> filters = new Dictionary<string, List<C>>();
        protected ConcurrentDictionary<string, List<C>> chunks = new ConcurrentDictionary<string, List<C>>();
        protected ConcurrentDictionary<Tuple<string[]>, C> tupleChunk = new ConcurrentDictionary<Tuple<string[]>, C>();
        protected List<Tuple<int, string[]>> tuples = new List<Tuple<int, string[]>>();
        protected NestDictionary<string, object> multiChunks = new NestDictionary<string, object>();
        protected string ChunkPrefixKey { get { return prefix_key ?? (prefix_key = Guid.NewGuid().ToString()); } }
        protected DBMSSystem db;
        protected string table_name = null;

        protected static T me;

        protected Loader(DBMSSystem qf, string table) { db = qf; table_name = table; }

        public void Add(C obj) { data.Add(obj); }

        protected void LoadData()
        {
            var chunkable = null != this.GetType().GetMethod("ChunkData");
            int count;
            RunQuery((query, schema_name) =>
                   {
                       if (chunkable)
                       {
                           this.GetType().GetMethod("ChunkData").Invoke(this, new object[] { query.Get<C>() });
                       }
                       else
                       {
                           data = query.Get<C>().ToList();
                       }
                   });
        }

        private void RunQuery(Action<Query, string> queryAct)
        {
            if (null == db || null == table_name) return;
            Action<Query, string> actn = (query, schema_name) =>
              {
                  if (null != this.GetType().GetMethod("CustomizeQuery")) this.GetType().GetMethod("CustomizeQuery").Invoke(this, new object[] { query, schema_name });
                  queryAct(query, schema_name);
              };
            if (null != this.GetType().GetMethod("GetChunk"))
            {
                Chunk ch = (Chunk)this.GetType().GetMethod("GetChunk").Invoke(this, null);
                db.RunFactory(ch, actn);
            }
            else
            {
                db.RunFactory(table_name, actn);
            }
        }

        public void Clean() { data.Clear(); filters.Clear(); }

        protected static T GetMe()
        {
            if (me != null) return me;
            me = new T();
            Log.Info($"Starting Data Load #Loader [{typeof(T).Name}]");
            ((Loader<T, C>)(object)me).LoadData();
            Log.Info($"Finished Data Load #Loader [{typeof(T).Name}]");
            return me;
        }

        protected void createFilter(string name, Predicate<C> filtFunc)
        {
            if (filters.ContainsKey(name)) return;
            Log.Info($"Creating Filter #{name}");
            filters.Add(name, data.FindAll(filtFunc));
            Log.Info($"Finished Filter #{name}");
        }

        protected List<C> searchAll(Predicate<C> sFunc, string name = null)
        {
            if (!string.IsNullOrEmpty(name)) createFilter(name, sFunc);
            Log.Info($"Searching All #{typeof(C).Name} [{name}]");
            return (!string.IsNullOrEmpty(name) && filters.ContainsKey(name) ? filters[name] : data).FindAll(sFunc);
        }

        protected C searchOne(Predicate<C> sFunc, string name = null)
        {
            if (!string.IsNullOrEmpty(name)) createFilter(name, sFunc);
            //  Log.Info($"Searching One #{typeof(C).Name} [{name}]");
            return (!string.IsNullOrEmpty(name) && filters.ContainsKey(name) ? filters[name] : data).Find(sFunc);
        }

        protected C QuerySearchOne(string condition, object[] parameters, Predicate<C> sFunc = null)
        {
            C res = default(C);
            if (null != sFunc && null != (res = searchOne(sFunc))) return res;
            // string key = SearchKey(condition, parameters);
            Log.Info($"Searching One {typeof(T).Name}-#{typeof(C).Name} [{condition}]");
            //  if (searches.ContainsKey(key)) return searches[key].First();
            try
            {
                RunQuery((query, schema_name) =>
                            {
                                res = query.WhereRaw(condition, parameters).FirstOrDefault<C>();
                                if (null != res) data.Add(res);
                            });
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }

            return res;
        }

        private string SearchKey(string condition, object[] parameters)
        {
            string key = condition;
            foreach (var param in parameters) key += param.ToString();
            return key.MD5();
        }

        public static void LoopAll(Action<C> looper)
        {
            var m = (Loader<T, C>)(object)GetMe();
            Log.Info($"Starting Looping Through All #{typeof(T).Name}");
            foreach (C c in m.data)
            {
                looper(c);
            }
            Log.Info($"Finished Looping Through All #{typeof(T).Name}");
        }
        protected static void LoopFilter(Predicate<C> fFunc, Action<C> filtrate, string name = null)
        {
            var m = (Loader<T, C>)(object)GetMe();
            var ls = m.searchAll(fFunc, name);
            foreach (C c in ls) filtrate(c);
        }

        #region ChunkData

        protected void AddChunkByKeys(C item, params long[] keys) => AddChunkByKeys(item, keys.Select(k => $"{k}").ToArray());
        protected void AddChunkByKeys(C item, params string[] keys)
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
            var me = ((Loader<T, C>)(object)GetMe());
            var res = keys.Where(k => me.chunks.ContainsKey(k)).Select(k => me.chunks[k].First());
            return res.Count() > 0 ? res.First() : default;
        }
        protected static C ChunkValue(params string[] keys) => ChunkValue(new string[][] { keys });
        protected static C ChunkValue(IEnumerable<string[]> keys) => ChunkValue(keys.ToArray());
        protected static C ChunkValue(string[][] keys) => ((Loader<T, C>)(object)GetMe()).IChunkValue(keys);

        protected C IChunkValue(string[][] keys)
        {
            C value;
            foreach (var iKeys in keys)
            {
                if (iKeys.Length <= 0 || iKeys.Where(k => !string.IsNullOrEmpty(k)).Count() == 0) continue;
                if (null != (value = multiChunks.FirstValue<string, C>(CKeys(iKeys, true)))) return value;
            }
            return default;
        }

        protected void ParallelChunk(List<Action<C>> actions, IEnumerable<C> items = null)
        {
            if (actions == null || 0 >= actions.Count)
            {
                Log.Info($"No Data Chunk Actions For #{typeof(T).Name}");
                if (null != items) data.AddRange(items);
                return;
            }
            Log.Info($"Starting Data Chunk #{typeof(T).Name}");
            Log.Info($"DataChunk Stats: Total Data to Chunk: #{items.Count()} [{typeof(T).Name}]");
            int count = 0;
            int iterations = 0;
            IEnumerable<C> cData = null != items ? items.ToArray() : data.ToArray();
            Parallel.ForEach(cData, new ParallelOptions { MaxDegreeOfParallelism = 5 }, dt =>
               {
                   Parallel.ForEach(actions, x => x(dt));
                   var br = Interlocked.Increment(ref count);
                   if (0 == br % Consts.LOOP_LOG_COUNT)
                   {
                       Log.Info($"Data Chunk Count {br} of {cData.Count()} #{typeof(T).Name}");
                   }
               });
            Log.Info($"DataChunk Stats: Total Lvl 1 Chunks: #{multiChunks.Count} [{typeof(T).Name}]");
            Log.Info($"Finished Data Chunk #{typeof(T).Name}");
        }

        private string[] CKeys(string[] keys, bool forVal = false)
        {
            return ((2 > keys.Length) && !forVal ? keys = CKeys(new string[] { ChunkPrefixKey, keys[0] }) : keys).Select(k => k ?? ChunkPrefixKey).ToArray();
        }

        protected C ChunkTuple(string[] keys)
        {
            return GetTupleKey(keys) is Tuple<string[]> tKey ? tupleChunk[tKey] : default;
        }

        private Tuple<string[]> GetTupleKey(string[] keys)
        {
            return tupleChunk.Keys.FirstOrDefault(tpl => keys.LooselySameAs(tpl.Item1)) is Tuple<string[]> _tuple ? _tuple : null;
        }

        #endregion
    }
}
