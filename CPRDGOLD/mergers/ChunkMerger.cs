using DBMS.models;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.mergers
{
    internal abstract class ChunkMerger<T, C> where T : new()
    {
        protected Chunk chunk;
        protected ConcurrentBag<C> data = new ConcurrentBag<C>();
        protected static ConcurrentDictionary<int, T> _instances = new ConcurrentDictionary<int, T>();
        protected ChunkMerger(Chunk chunk) { this.chunk = chunk; chunk.AddCleaner(Clear); }

        public ChunkMerger() { }

        protected void Add(C c) => data.Add(c);

        public static T Init(Chunk chunk)
        {
            var _inst = new T();
            ((ChunkMerger<T, C>)(object)_inst).chunk = chunk;
            Log.Info($"Starting Data Load #ChunkMerger [{typeof(T).Name}]");
            ((ChunkMerger<T, C>)(object)_inst).LoadData();
            Log.Info($"Finished Data Load #ChunkMerger [{typeof(T).Name}]");
            return _inst;
        }

        public ConcurrentBag<C> GetData() => data;

        public void Clear()
        {
            data = new ConcurrentBag<C>();
            Log.Warning("Cleaning #{name}", typeof(T).Name);
        }

        /*
         protected static T GetMe(Chunk chunk)
        {
            if (_instances.ContainsKey(chunk.ordinal)) return _instances[chunk.ordinal];
            _instances[chunk.ordinal] = new T();
            ((ChunkMerger<T, C>)(object)_instances[chunk.ordinal]).chunk = chunk;
            Log.Info($"Starting Data Load #ChunkMerger [{typeof(T).Name}]");
            ((ChunkMerger<T, C>)(object)_instances[chunk.ordinal]).LoadData();
            Log.Info($"Finished Data Load #ChunkMerger [{typeof(T).Name}]");
            return _instances[chunk.ordinal];
        }

         public static void LoopAll(Chunk chunk, Action<C> looper)
         {
             ((ChunkMerger<T, C>)(object)GetMe(chunk)).LoopAllData(looper);
         }
        */

        public void LoopAllData(Action<C> looper)
        {
            Log.Info($"Starting LoopAll #{typeof(T).Name}");
            Log.Info($"Total Data To LoopAll [{data.Count}] #{typeof(T).Name}");
            foreach (C c in data) looper(c);
            Log.Info($"Finished LoopAll #{typeof(T).Name}");
        }

        protected abstract void LoadData();
    }
}
