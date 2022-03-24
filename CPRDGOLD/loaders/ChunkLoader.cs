using DBMS;
using DBMS.systems;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    public abstract class ChunkLoader<T, C> : Loader<T, C> where T : new()
    {
        Chunk chunk;
        protected string chunkColumn = "patid";
        public ChunkLoader(string table_name, Chunk chunk) : base(DB.Source, table_name) { this.chunk = chunk; chunk.AddCleaner(() => this.Clean()); }
        public ChunkLoader(string table_name) : base(DB.Source, table_name) { }

        public Chunk GetChunk()
        {
            return chunk ?? (chunk = new Chunk
            {
                column = "patient_id",
                ordinal = 0,
                relationColumn = chunkColumn,
                tableName = "_chunk",
                dbms = DB.Target,
                ordinalColumn = "ordinal",
                relationTableName = table_name,
            });
        }


        protected static T GetMe(Chunk chunk)
        {
            if (me != null) return me;
            me = new T();// (T)Activator.CreateInstance(typeof(T), new object[] { chunk });// new T(chunk);
            ((ChunkLoader<T, C>)(object)me).chunk = chunk;
            Log.Info($"Starting Chunk Data Load #ChunkLoader [{typeof(T).Name}]");
            ((ChunkLoader<T, C>)(object)me).LoadData();
            Log.Info($"Finished Chunk Data Load #ChunkLoader [{typeof(T).Name}]");
            return me;
        }

        public static void LoopAll(Chunk chunk, Action<C> looper)
        {
            Log.Info($"Starting Chunk LoopAll #ChunkLoader [{typeof(T).Name}]");
            var m = (ChunkLoader<T, C>)(object)GetMe(chunk);
            foreach (C c in m.data) looper(c);
            Log.Info($"Finished Chunk LoopAll #ChunkLoader [{typeof(T).Name}]");
        }
        protected static void LoopFilter(Chunk chunk, Predicate<C> fFunc, Action<C> filtrate, string name = null)
        {
            var ls = ((ChunkLoader<T, C>)(object)GetMe(chunk)).searchAll(fFunc, name);
            foreach (C c in ls) filtrate(c);
        }
        protected static new T GetMe() { throw new NotImplementedException(); }
        protected static new T LoopAll(Action<C> looper) { throw new NotImplementedException(); }
        protected static new T LoopFilter(Predicate<C> fFunc, Action<C> filtrate, string name = null) { throw new NotImplementedException(); }
    }
}
