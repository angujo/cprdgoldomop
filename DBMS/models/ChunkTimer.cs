using System;
using Util;

namespace DBMS.models
{
    public class Chunktimer : CRUDModel<Chunktimer>
    {
        public int ChunkId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool Touched { get; set; }
        public long WorkLoadId { get; set; }
        public Status Status { get; set; }
        public string ErrorLog { get; set; }

        public void Start()
        {
            StartTime = DateTime.Now;
            Status = Status.RUNNING;
            Save();
        }

        public void Stop(Exception ex = null)
        {
            ErrorLog = null == ex ? ex.Message + "\n" + ex.StackTrace : null;
            Status = Status.STOPPED;
            EndTime = DateTime.Now;
            Save();
        }

        public void Implemented()
        {
            EndTime = DateTime.Now;
            Status = Status.FINISHED;
            Save();
        }
    }
}
