using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DBMS;
using DBMS.models;
using Util;

namespace AppUI.models
{
    internal class UIChunks : UIModel
    {
        public  int                     status  { get; set; }
        public  int                     chunkId { get; set; }
        public  Dictionary<int, string> statuses = new Dictionary<int, string>();
        private long                    workload_id;

        public UIChunks(long workloadId)
        {
            workload_id = workloadId;
            PopulateStatuses();
        }

        private void PopulateStatuses()
        {
            statuses.Add(-1, "* Any");
            Status[] st = {Status.RUNNING, Status.STOPPED, Status.FINISHED, Status.SCHEDULED};
            foreach (var s in st)
            {
                statuses.Add((int) s, s.GetStringValue());
            }
        }

        public void LoadChunks(Action<object[]> action)
        {
            var where = new List<string> {$"workloadid = {workload_id}"};
            var _w    = "";
            if (status > -1) where.Add($"status = {status}");
            if (chunkId > -1) where.Add($"chunkid = {chunkId}");

            if (where.Count > 0) _w = "WHERE " + string.Join(" AND ", where);
            foreach (var chunktimer in DB.Internal.GetAll<Chunktimer>(_w))
            {
                action(new Object[]
                {
                    chunktimer.Chunkid,
                    chunktimer.Starttime?.ToString("yy-MMM-dd ddd HH:m:s"),
                    chunktimer.Endtime?.ToString("yy-MMM-dd ddd HH:m:s"),
                    null != chunktimer.Starttime
                        ? chunktimer.Endtime?.Subtract((DateTime) chunktimer.Starttime).ToString()
                        : "",
                    chunktimer.Status.GetStringValue(),
                });
            }
        }
    }
}