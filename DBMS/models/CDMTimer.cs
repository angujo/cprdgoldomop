using Dapper;
using System;
using Util;

namespace DBMS.models
{
    [Table("cdmtimer")]
    public class CDMTimer : CRUDModel<CDMTimer>
    {
        [Column("name")]
        public string Name { get; set; }
        public int ChunkId { get; set; }
        public string Query { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public long WorkLoadId { get; set; }
        public Util.Status Status { get; set; }
        public string ErrorLog { get; set; }

        [Editable(false)]
        public Util.LoadType LoadType { get; set; }
        [Editable(false)]
        public bool IsPending { get { return Status != Status.FINISHED; } }
        [Editable(false)]
        public bool IsDone { get { return Status == Status.FINISHED; } }

        public void Start()
        {
            StartTime = DateTime.Now;
            Status = Status.RUNNING;
            Save();
        }

        public void Stop()
        {
            EndTime = DateTime.Now;
            Save();
        }

        public void Implemented()
        {
            Status = Status.FINISHED;
            Stop();
        }

        public void Implement(Action impl)
        {
            if (IsDone) return;
            Start();
            try
            {
                impl();
                Implemented();
            }
            catch (Exception ex)
            {
                Status = Status.STOPPED;
                ErrorLog = ex.Message + "\n" + ex.StackTrace;
                Log.Error(ex);
                Stop();
                throw;
            }
        }
    }
}
