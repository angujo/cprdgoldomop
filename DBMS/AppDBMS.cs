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
                Status = Status.RUNNING,

            };
            workqueue.Save();
        }

        public void StopQueue(Exception ex = null)
        {
            workqueue.Status = ex == null ? Status.FINISHED : Status.STOPPED;
            workqueue.ErrorLog = ex.Message + "\n" + ex.StackTrace;
            workqueue.Save();
        }

        public IEnumerable<int> ChunkOrdinals()
        {
            foreach (var ct in DB.Internal.GetAll<Chunktimer>("WHERE chunkid > 0 AND workloadid = @WLId AND (status IS NULL OR status <> @Stat)", new { WLId = workload.Id, Stat = Status.FINISHED })) yield return ct.ChunkId;
        }

        public void CleanUpChunks()
        {
            DB.Internal.RunQuery("update chunktimer set status = $1 from cdmtimer d " +
                "where d.chunkid = chunktimer.chunkid and d.workloadid = chunktimer.workloadid and d.status <> $2 AND d.workloadid = $3",
                Status.SCHEDULED, Status.FINISHED, workload.Id);
        }
    }
}
