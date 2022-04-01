using DBMS.models;
using System;
using System.Collections.Generic;
using Util;

namespace DBMS
{
    public class AppDBMS
    {
        public WorkLoad workload { get; private set; }
        public WorkQueue workqueue { get; private set; }

        public AppDBMS()
        {
            workload = DB.Internal.Load<WorkLoad>(new { cdmprocessed = false });
            if (workload.Exists()) Chunk.WorkLoadId = (long)workload.Id;
        }

        public void StartQueue()
        {
            workqueue = new WorkQueue
            {
                WorkLoadId = (long)workload.Id,
                Name = Guid.NewGuid().ToString(),
                StartTime = DateTime.Now,
                Status = Util.Status.RUNNING,
                
            };
            workqueue.Save();
        }

        public void StopQueue(Exception ex = null)
        {
            workqueue.Status = ex == null ? Util.Status.FINISHED : Util.Status.STOPPED;
            workqueue.Save();
        }

        public IEnumerable<int> ChunkOrdinals()
        {
            foreach (var ct in DB.Internal.GetAll<Chunktimer>("WHERE chunkid > 0 AND workloadid = @WLId AND (status IS NULL OR status <> @Stat)", new { WLId = workload.Id, Stat = Status.FINISHED })) yield return ct.ChunkId;
        }

    }
}
