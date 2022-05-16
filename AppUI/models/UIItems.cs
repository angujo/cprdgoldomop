using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DBMS;
using DBMS.models;
using Util;

namespace AppUI.models
{
    internal class UIItems : UIModel
    {
        public int    status  { get; set; }
        public int    chunkId { get; set; }
        public int    type    { get; set; }
        public string name    { get; set; }

        public Dictionary<int, string>    statuses = new Dictionary<int, string>();
        public Dictionary<int, string>    types    = new Dictionary<int, string>();
        public Dictionary<string, string> names    = new Dictionary<string, string>();

        public UIItems()
        {
            PopulateNames();
            PopulateStatuses();
            PopulateTypes();
        }

        private void PopulateNames()
        {
            names.Add("*", "* Any");
            var loadTypes = Enum.GetValues(typeof(LoadType)).Cast<LoadType>();
            foreach (var loadType in loadTypes)
            {
                names.Add(loadType.GetStringValue(), loadType.GetStringValue().ToWords());
            }
        }

        private void PopulateTypes()
        {
            types.Add(-99, "* Any");
            types.Add(-1, "Workload Setup");
            types.Add(-2, "Indices");
            types.Add(-3, "Post Chunk Setup");
            types.Add(0, "Chunk Based");
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

        public void LoadItems(Action<Object[]> action)
        {
            var where = new List<string>();
            var _w    = "";
            if (status > -1) where.Add($"status = {status}");
            if (null!=name && name != "*" && name.Trim().Length>0) where.Add($"name = '{name}'");
            if (type > -99)
            {
                if (type < 0) where.Add($"chunkid = {type}");
                else if (type >= 0 && chunkId >= 0) where.Add($"chunkid = {chunkId}");
            }

            if (where.Count > 0) _w = "WHERE " + string.Join(" AND ", where);
            foreach (var cdmtimer in DB.Internal.GetAll<Cdmtimer>(_w))
            {
                action(new Object[]
                {
                    cdmtimer.ChunkId + "", cdmtimer.Name, cdmtimer.StartTime?.ToString(), cdmtimer.EndTime?.ToString(),
                    cdmtimer.StartTime == null
                        ? ""
                        : cdmtimer.EndTime?.Subtract((DateTime) cdmtimer.StartTime).ToString(),
                    cdmtimer.Status.GetStringValue(), cdmtimer.ErrorLog?.Truncate(100)
                });
            }
        }
    }
}