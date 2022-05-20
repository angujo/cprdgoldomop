using DBMS.models;
using System;
using System.Collections.Generic;
using System.Linq;
using SqlKata.Execution;
using Util;

namespace DBMS
{
    public class AppDBMS
    {
        public WorkLoad  workload  { get; private set; }
        public WorkQueue workqueue { get; private set; }

        public AppDBMS()
        {
            workload = DB.Internal.Load<WorkLoad>(new {cdmprocessed = false, status = Status.SCHEDULED});
            if (null != workload && workload.Exists()) Chunk.WorkLoadId = workload.Id;
        }

        public void StartQueue()
        {
            workqueue = new WorkQueue
            {
                WorkLoadId = workload.Id,
                Name       = Guid.NewGuid().ToString(),
                StartTime  = DateTime.Now,
                Status     = Status.RUNNING,
            };
            workqueue.Save();

            DB.Internal.Update<WorkLoad>(new {isrunning = false}, new {isrunning = true});
            workload.Isrunning = true;
            workload.intervene = false;
            workload.Status    = Status.RUNNING;
            workload.Save();
        }

        public void StopQueue(Exception ex = null)
        {
            workqueue.Status   = ex == null ? Status.FINISHED : Status.STOPPED;
            workqueue.ErrorLog = ex == null ? null : ex.Message + "\n" + ex.StackTrace;
            workqueue.Save();

            workload.Isrunning = false;
            workload.Status    = ex == null ? Status.FINISHED : Status.STOPPED;
            workload.Save();
        }

        public IEnumerable<int> ChunkOrdinals()
        {
            return DB.Internal.GetAll<Chunktimer>(
                "WHERE chunkid >= 0 AND workloadid = @WLId AND (status IS NULL OR status <> @Stat)",
                new {WLId = workload.Id, Stat = Status.FINISHED}).Select(ct => ct.Chunkid);
        }

        public void CleanupNonChunk(int chunkId, string colName)
        {
            if (chunkId >= 0) return;
            DB.Internal.RunFactory(db =>
            {
                db.Statement(
                    $"update work_load set {colName} = not exists (select 1 from cdmtimer c " +
                    $"where (c.status <> :Fstat OR c.status IS NULL) and chunkid = :CId and c.workloadid = work_load.id) " +
                    "WHERE id = :Wlid;",
                    new {Fstat = (int) Status.FINISHED, CId = chunkId, Wlid = workload.Id});
                ReloadWorkPlan();
            });
        }

        public void CleanUpChunks()
        {
            DB.Internal.RunFactory(db =>
            {
                db.Statement("update chunktimer set status = :Nstat from cdmtimer d " +
                             "where d.chunkid = chunktimer.chunkid and d.workloadid = chunktimer.workloadid and d.status <> :Fstat AND d.workloadid = :Wlid",
                             new {Nstat = (int) Status.SCHEDULED, Fstat = (int) Status.FINISHED, Wlid = workload.Id});

                db.Statement(
                    "update work_load set chunksloaded = not exists (select 1 from chunktimer c where (c.status <> :Fstat or c.status IS NULL) and chunkid >=0 and c.workloadid = work_load.id) " +
                    "WHERE id = :Wlid;",
                    new {Fstat = (int) Status.FINISHED, Wlid = workload.Id});
                ReloadWorkPlan();
            });
        }

        public WorkLoad ReloadWorkPlan()
        {
            //Reload WorkPlan with new status
            return workload = DB.Internal.Load<WorkLoad>(new {id = workload.Id});
        }
    }
}