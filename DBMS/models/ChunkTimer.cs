using System;
using Util;

namespace DBMS.models
{
    public class Chunktimer : CRUDModel<Chunktimer>
    {
        public int Chunkid { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public bool Touched { get; set; }
        public long Workloadid { get; set; }
        public Status Status { get; set; }
        public string Errorlog { get; set; }

        public void Start()
        {
            Starttime = DateTime.Now;
            Status = Status.RUNNING;
            Save();
        }

        public void Stop(Exception ex = null)
        {
            Errorlog = null == ex ? ex.Message + "\n" + ex.StackTrace : null;
            Status = Status.STOPPED;
            Endtime = DateTime.Now;
            Save();
        }

        public void Implemented()
        {
            Endtime = DateTime.Now;
            Status = Status.FINISHED;
            Save();
        }
    }
}
