using DBMS;
using DBMS.systems;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        protected NestDictionary<string, object> multiChunks = new NestDictionary<string, object>();
        protected string ChunkPrefixKey { get { return prefix_key ?? (prefix_key = Guid.NewGuid().ToString()); } }
        protected DBMSSystem db;
        protected string table_name = null;

        protected static T me;

        protected Loader(DBMSSystem qf, string table) { db = qf; table_name = table; }

        public void Add(C obj) { data.Add(obj); }

        protected void LoadData()
        {
            RunQuery((query, schema_name) =>
                   {
                       data = query.Get<C>().ToList();
                   });
            if (null != this.GetType().GetMethod("ChunkData")) this.GetType().GetMethod("ChunkData").Invoke(this, null);
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
    }
}
