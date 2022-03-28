using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD
{
    internal abstract class ADataLoader<T> where T : new()
    {
        protected static T me;
        protected ConcurrentBag<T> data = new ConcurrentBag<T>();

        protected abstract void LoadData();

        protected static T GetMe()
        {
            if (me != null) return me;
            me = new T();
            Log.Info($"Starting Data Load [{typeof(T).Name}]");
            ((ADataLoader<T>)(object)me).LoadData();
            Log.Info($"Finished Data Load [{typeof(T).Name}]");

            return me;
        }

        public static ConcurrentBag<T> GetData() => ((ADataLoader<T>)(object)GetMe()).data;
        public void Add(T obj) => data.Add(obj);

        public void Clean() => data = new ConcurrentBag<T>();
    }
}
