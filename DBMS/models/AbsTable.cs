using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace AppControl.models
{
    public abstract class AbsTable<T>
    {
        // Hold the ID here
        private Int64? _id;

        public abstract bool Save();
        public abstract T Load();
        public abstract void Update();
        public abstract T GetById(int id);
        public abstract IEnumerable<T> GetAll();
    }
}
