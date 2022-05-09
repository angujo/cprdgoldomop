using DBMS;
using DBMS.models;

namespace AppUI.models
{
    public class UIWorkLoad
    {
        private WorkLoad WorkLoad { get; set; }

        public UIWorkLoad(long id)
        {
            WorkLoad = DB.Internal.Load<WorkLoad>(new {id});
        }

        public UIWorkLoad(WorkLoad wl)
        {
            WorkLoad = wl;
        }

        public WorkLoad GetWorkload() => WorkLoad;
    }
}