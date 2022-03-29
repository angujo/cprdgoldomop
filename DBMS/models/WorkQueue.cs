using System;
using System.Collections.Generic;
using Util;

namespace DBMS.models
{
    internal class WorkQueue : CRUDModel
    {
        public long WorkLoadId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Status Status { get; set; }
        public int? ProgressPercent { get; set; }

        WorkLoad wl;

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

        public static WorkQueue NextAvailable() { return ByStatusAvailable(); }

        private static WorkQueue ByStatusAvailable()
        {
            var stats = new Status[] { Status.SCHEDULED, Status.RUNNING, Status.STOPPED }; //The order in which queues to be accessed
            foreach (var stat in stats)
            {
                var sts = DB.Internal.Load<WorkQueue>(new { Status = stat });
                if (sts != null) return sts;
            }
            return null;
        }

        public WorkLoad WorkLoad() => wl ?? (wl = DB.Internal.Load<WorkLoad>(new { Id = WorkLoadId }));
    }
}
