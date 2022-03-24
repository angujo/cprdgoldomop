using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.mergers
{
    internal abstract class ChunkMerger<T, C> where T : new()
    {
        protected Chunk chunk;
        protected List<C> data = new List<C>();
        protected static T me;
        protected ChunkMerger(Chunk chunk) { this.chunk = chunk; chunk.AddCleaner(Clear); }

        public ChunkMerger() { }

        protected void Add(C c) { data.Add(c); }

        public static List<C> GetData(Chunk chunk) => ((ChunkMerger<T, C>)(object)GetMe(chunk)).data;

        public void Clear() { data.Clear(); me = default; }

        protected static T GetMe(Chunk chunk)
        {
            if (me != null) return me;
            me = new T();// (T)Activator.CreateInstance(typeof(T), new object[] { chunk });
            ((ChunkMerger<T, C>)(object)me).chunk = chunk;
            Log.Info($"Starting Data Load #ChunkMerger [{typeof(T).Name}]");
            ((ChunkMerger<T, C>)(object)me).Load();
            Log.Info($"Finished Data Load #ChunkMerger [{typeof(T).Name}]");
            return me;
        }

        public static void LoopAll(Chunk chunk, Action<C> looper)
        {
            Log.Info($"Starting LoopAll #{typeof(T).Name}");
            var m = (ChunkMerger<T, C>)(object)GetMe(chunk);
            foreach (C c in m.data) looper(c);
            Log.Info($"Finished LoopAll #{typeof(T).Name}");
        }

        protected abstract void Load();
    }
}
