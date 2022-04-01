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
            workqueue.ErrorLog = ex == null ? null : ex.Message + "\n" + ex.StackTrace;
            workqueue.Save();
        }

        public IEnumerable<int> ChunkOrdinals()
        {
            foreach (var ct in DB.Internal.GetAll<Chunktimer>("WHERE chunkid >= 0 AND workloadid = @WLId AND (status IS NULL OR status <> @Stat)", new { WLId = workload.Id, Stat = Status.FINISHED })) yield return ct.ChunkId;
        }

        public void CleanUpChunks()
        {
            DB.Internal.RunFactory(db =>
            {
                db.Statement("update chunktimer set status = :Nstat from cdmtimer d " +
                "where d.chunkid = chunktimer.chunkid and d.workloadid = chunktimer.workloadid and d.status <> :Fstat AND d.workloadid = :Wlid",
                new { Nstat = (int)Status.SCHEDULED, Fstat = (int)Status.FINISHED, Wlid = workload.Id });

                db.Statement("update work_load set cdmprocessed =true where not exists (select 1 from chunktimer c " +
                    "where (c.status is null or c.status <> :Fstat) and c.workloadid=work_load.id);",
                new { Fstat = (int)Status.FINISHED, });
            });
        }
    }
}
