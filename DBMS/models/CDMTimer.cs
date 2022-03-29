using Dapper;
using System;

namespace DBMS.models
{
    public class CDMTimer : CRUDModel
    {
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

        public void Start()
        {
            StartTime = DateTime.Now;
            Save();
        }

        public void Stop()
        {
            EndTime = DateTime.Now;
            Save();
        }

        public bool IsDone() => Status == Util.Status.FINISHED;
    }
}
