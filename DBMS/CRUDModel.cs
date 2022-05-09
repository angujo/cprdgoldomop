using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Util;

namespace DBMS
{
    public abstract class CRUDModel<T> where T : class
    {
        private string _conn;

        public long Id { get; set; }

        [Editable(false)]
        public string ConnectionString { get { return _conn ?? Setting.AppConnection; } }

        [Editable(false)]
        protected string TableName { get { return this.GetType().Name; } }

        public bool Exists() => default != Id;

        public void SetConnectionString(string conn_str) { _conn = conn_str; }

        private void Execute(Action<IDbConnection> act)
        {
            if (ConnectionString == null) return;
            DB.Internal.RunConnection(act);
        }

        public void Save()
        {
            if (!Exists()) Id = DB.Internal.Insert<T>((T)(object)this);
            else DB.Internal.Update((T)(object)this, new { id = Id });
        }

        protected List<string> FillableColumns()
        {
            return this.GetType().GetProperties()
                .Where(pi =>
                {
                    if ("id" == pi.Name.ToLower()) return false;
                    var attrs = pi.GetCustomAttributes(true);
                    if (attrs.Length <= 0) return true;
                    var ea = attrs.FirstOrDefault(a => a is EditableAttribute);
                    return ea == null || ((EditableAttribute)ea).AllowEdit;
                }).Select(p => p.Name.ToLower()).ToList();
        }

        public PropertyInfo[] GetColumns()
        {
            return  this.GetType().GetProperties()
                           .Where(pi =>
                           {
                               if ("id" == pi.Name.ToLower()) return false;
                               var attrs = pi.GetCustomAttributes(true);
                               if (attrs.Length <= 0) return true;
                               object ea;
                               if (null == (ea = attrs.FirstOrDefault(a => a is SaveableAttribute || a is EditableAttribute))) return true;
                               return (ea is SaveableAttribute sa && sa.AllowSave) || (ea is EditableAttribute da && da.AllowEdit);
                           }).ToArray();
        }
    }
}
