using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DBMS.models;
using DBMS.systems;
using SqlKata;
using SqlKata.Execution;
using Util;

namespace CPRDGOLD.loaders
{
    public abstract class Loader<T, C> where T : new()
    {
        protected List<C>                         data       = new List<C>();
        protected ConcurrentDictionary<string, C> tupleChunk = new ConcurrentDictionary<string, C>();
        protected DBMSSystem                      db { get; set; }

        protected List<C> dataset
        {
            get { return data.Count > 0 ? data : tupleChunk.Select(tc => tc.Value).ToList(); }
        }

        protected string table_name;

        protected static T me;

        protected Loader(DBMSSystem qf, string table)
        {
            db         = qf;
            table_name = table;
        }

        public void Add(C obj)
        {
            data.Add(obj);
        }

        public static void Init() => GetMe();

        public static List<C> GetData() => ((Loader<T, C>) (object) GetMe()).dataset;

        protected void LoadData()
        {
            RunQuery((query, schema_name) =>
            {
                if (null != GetType().GetMethod("ChunkData"))
                {
                    GetType().GetMethod("ChunkData").Invoke(this, new object[] {query.Get<C>()});
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
                if (null != GetType().GetMethod("CustomizeQuery"))
                    GetType().GetMethod("CustomizeQuery").Invoke(this, new object[] {query, schema_name});
                queryAct(query, schema_name);
            };
            if (null != GetType().GetMethod("GetChunk"))
            {
                Chunk ch = (Chunk) GetType().GetMethod("GetChunk").Invoke(this, null);
                db.RunChunk(ch, table_name, actn);
            }
            else
            {
                db.RunFactory(table_name, actn);
            }
        }

        public void Clean()
        {
            data.Clear();
            tupleChunk.Clear();
            Log.Warning("Cleaning #{name}", typeof(T).Name);
        }

        protected static T GetMe()
        {
            if (me != null) return me;
            me = new T();
            var _me = (Loader<T, C>) (object) me;
            Log.Info($"Starting Data Load #Loader [{typeof(T).Name}]");
            _me.LoadData();
            Log.Info(
                $"Finished Data Load #Loader {_me.data.Count}/{_me.tupleChunk.Count} (data/tuples) [{typeof(T).Name}]");
            return me;
        }

        public static void LoopAll(Action<C> looper)
        {
            var m = (Loader<T, C>) (object) GetMe();
            Log.Info($"Starting Looping Through All #{typeof(T).Name}");
            var _data = m.data.Count > 0 || null == m.GetType().GetMethod("ChunkData")
                ? m.data
                : m.tupleChunk.Select(tc => tc.Value).ToList();
            Log.Info($"Total Data Chunk to LoopAll [{_data.Count}] [{typeof(T).Name}]");
            foreach (C c in _data)
            {
                looper(c);
            }

            Log.Info($"Finished Looping Through All #{typeof(T).Name}");
        }

        #region ChunkData

        protected C IChunkValue(string[][] keys)
        {
            foreach (var iKeys in keys)
            {
                if (iKeys.Length <= 0 || iKeys.Where(k => string.IsNullOrEmpty(k)).Count() > 0) continue;
                if (ChunkTupleValue(iKeys) is C value) return value;
            }

            return default;
        }

        protected void ParallelChunk(IEnumerable<C> items = null) => IParallelChunk(null, items);

        protected void ParallelChunk(Func<C, string[]> getKeys, IEnumerable<C> items = null) =>
            ParallelChunk(c => new[] {getKeys(c)}, items);

        protected void ParallelChunk(Func<C, string[][]> getKeys, IEnumerable<C> items = null) =>
            IParallelChunk(getKeys, items);

        private void IParallelChunk(Func<C, string[][]> getKeys, IEnumerable<C> items = null)
        {
            if (getKeys == null)
            {
                Log.Info($"No Data Chunk Actions For #{typeof(T).Name}");
                if (null != items) data.AddRange(items);
                return;
            }

            Log.Info($"Starting Data Chunk #{typeof(T).Name}");
            Log.Info($"DataChunk Stats: Total Data to Chunk: #{items.Count()} [{typeof(T).Name}]");
            int            count = 0;
            IEnumerable<C> cData = null != items ? items.ToArray() : data.ToArray();
            Parallel.ForEach(cData,
                             new ParallelOptions {MaxDegreeOfParallelism = 50, CancellationToken = Runner.Token},
                             dt =>
                             {
                                 string[][] keys;
                                 if (null == (keys = getKeys(dt))) return;
                                 foreach (var _keys in keys)
                                 {
                                     if (_keys.HasNullOrEmpty()) continue;
                                     var ky = string.Join(".", _keys);
                                     if (tupleChunk.ContainsKey(ky)) continue;
                                     tupleChunk[ky] = dt;
                                 }

                                 var br = Interlocked.Increment(ref count);
                                 if (0 == br % Consts.LOOP_LOG_COUNT)
                                 {
                                     Log.Info($"Data Chunk Count {br} of {cData.Count()} #{typeof(T).Name}");
                                 }
                             });
            Log.Info($"DataChunk Stats: Total Chunks: #{tupleChunk.Count}/{cData.Count()} [{typeof(T).Name}]");
            Log.Info($"Finished Data Chunk #{typeof(T).Name}");
        }

        protected C ChunkTupleValue(string[] keys)
        {
            var tKey = string.Join(".", keys);
            return !keys.HasNullOrEmpty() && tupleChunk.ContainsKey(tKey) ? tupleChunk[tKey] : default;
        }

        #endregion
    }
}