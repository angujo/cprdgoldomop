using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    public abstract class CRUDModel
    {
        private string _conn;

        public long? Id { get; set; }

        [Editable(false)]
        public string ConnectionString { get { return _conn; } }

        public void SetConnectionString(string conn_str) { _conn = conn_str; }

        private void Execute(Action<IDbConnection> act)
        {
            if (ConnectionString == null) return;
            DB.Internal.RunConnection(act);
        }

        public void Save()
        {
            Execute(conn =>
            {
                if (null == Id || 0 == Id)
                    Id = conn.Insert(this);
                else conn.Update(this);
            });
        }
    }
}
