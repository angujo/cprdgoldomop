using Dapper;
using System;
using Util;

namespace DBMS.models
{
    [Table("cdm_timer")]
    public class Cdmtimer : CRUDModel<Cdmtimer>
    {
        [Column("name")] public string Name { get; set; }

        public int         Chunkid    { get; set; }
        public string      Query      { get; set; }
        public DateTime?   Starttime  { get; set; }
        public DateTime?   Endtime    { get; set; }
        public long        Workloadid { get; set; }
        public Util.Status Status     { get; set; }
        public string      Errorlog   { get; set; }

        [Editable(false)] public Util.LoadType LoadType { get; set; }

        [Editable(false)]
        public bool IsPending
        {
            get { return Status != Status.FINISHED; }
        }

        [Editable(false)]
        public bool IsDone
        {
            get { return Status == Status.FINISHED; }
        }

        public void Start()
        {
            Starttime = DateTime.Now;
            Status    = Status.RUNNING;
            Save();
        }

        public void Stop()
        {
            Endtime = DateTime.Now;
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
            Log.Info($"Starting implementation of {Name}");
            Start();
            try
            {
                impl();
                Implemented();
            }
            catch (Exception ex)
            {
                Status   = Status.STOPPED;
                Errorlog = ex.Message + "\n" + ex.StackTrace;
                Log.Error(ex);
                Stop();
                throw;
            }
            finally
            {
                Log.Info($"Finished implementation of {Name}");
            }
        }
    }
}