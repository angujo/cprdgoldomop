using DBMS.models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        protected void Add(C c) { data.Add(c); }

        public static ConcurrentBag<C> GetData(Chunk chunk) => ((ChunkMerger<T, C>)(object)GetMe(chunk)).data;

        public void Clear() { data = new ConcurrentBag<C>(); }

        protected static T GetMe(Chunk chunk)
        {
            if (_instances[chunk.ordinal] != null) return _instances[chunk.ordinal];
            _instances[chunk.ordinal] = new T();
            ((ChunkMerger<T, C>)(object)_instances[chunk.ordinal]).chunk = chunk;
            Log.Info($"Starting Data Load #ChunkMerger [{typeof(T).Name}]");
            ((ChunkMerger<T, C>)(object)_instances[chunk.ordinal]).LoadData();
            Log.Info($"Finished Data Load #ChunkMerger [{typeof(T).Name}]");
            return _instances[chunk.ordinal];
        }

        public static void LoopAll(Chunk chunk, Action<C> looper)
        {
            Log.Info($"Starting LoopAll #{typeof(T).Name}");
            var m = (ChunkMerger<T, C>)(object)GetMe(chunk);
            Log.Info($"Total Data To LoopAll [{m.data.Count}] #{typeof(T).Name}");
            var count = 0;
            Parallel.ForEach(m.data, cd =>
             {
                 looper(cd);
                 var br = Interlocked.Increment(ref count);
                 if (0 == br % Consts.LOOP_LOG_COUNT)
                 {
                     Log.Info($"ChunkMerger Count {br} of {m.data.Count} #{typeof(T).Name}");
                 }
             });
            // foreach (C c in m.data) looper(c);
            Log.Info($"Finished LoopAll #{typeof(T).Name}");
        }

        protected abstract void LoadData();
    }
}
