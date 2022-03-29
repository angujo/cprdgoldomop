using DBMS.models;
using DBMS.systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    public class AppDBMS
    {
        private WorkLoad workload;

        protected AppDBMS()
        {
            workload = DB.Internal.Load<WorkLoad>(new { cdmprocessed = false });
        }

        public static void Set()
        {
            var m = new AppDBMS();
        }

    }
}
