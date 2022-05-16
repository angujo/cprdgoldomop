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
        public int                     status  { get; set; }
        public int                     chunkId { get; set; }
        public Dictionary<int, string> statuses = new Dictionary<int, string>();

        public UIChunks()
        {
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

        public void LoadChunks(Action<Object[]> action)
        {
            var where = new List<string>();
            var _w    = "";
            if (status > -1) where.Add($"status = {status}");
            if (chunkId > -1) where.Add($"chunkid = {chunkId}");

            if (where.Count > 0) _w = "WHERE " + string.Join(" AND ", where);
            foreach (var chunktimer in DB.Internal.GetAll<Chunktimer>(_w))
            {
                action(new Object[]
                {
                    chunktimer.ChunkId,
                    chunktimer.StartTime?.ToString("yy-MMM-dd ddd HH:m:s"),
                    chunktimer.EndTime?.ToString("yy-MMM-dd ddd HH:m:s"),
                    null != chunktimer.StartTime
                        ? chunktimer.EndTime?.Subtract((DateTime) chunktimer.StartTime).ToString()
                        : "",
                    chunktimer.Status.GetStringValue(),
                });
            }
        }
    }
}