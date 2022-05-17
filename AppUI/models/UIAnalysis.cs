using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DBMS;
using DBMS.models;
using Util;

namespace AppUI.models
{
    public class UIAnalysis : UIModel
    {
        private long workload_id;

        public UIAnalysis(long work_id)
        {
            workload_id = work_id;
        }

        public void LoadAnalysis(Action<object[]> action)
        {
            foreach (var analysis in theData())
            {
                // var lv = new ListViewItem();
                // lv.SubItems.Add();
                action(new object[] {analysis.txt, analysis.value});
            }
        }

        private IEnumerable<StatusView> theData()
        {
            long     totalChunks = 0, finishedChunks = 0;
            TimeSpan chunkTime   = default;
            foreach (var statusView in DB.Internal.GetAll<StatusView>("WHERE workloadid = @wlid",
                                                                      new {wlid = workload_id}))
            {
                var key = Regex.Replace(statusView.code, @"([A-Za-z_]+)(_(.*?))?$", @"$1");
                var num = Int64.TryParse(Regex.Replace(statusView.code, @"([A-Za-z_]+)(_(.*?))?$", @"$3"), out long nm)
                    ? nm
                    : 0;
                switch (key)
                {
                    case "item_dur":
                        continue;
                    case "item_count":
                        statusView.txt = ((Status) num).GetStringValue() + " Items Count";
                        break;
                    case "chunk_count":
                        statusView.txt =  ((Status) num).GetStringValue() + " Chunks Count";
                        totalChunks    += Convert.ToInt64(statusView.value);
                        if ((int) Status.FINISHED == num) finishedChunks += Convert.ToInt64(statusView.value);
                        break;
                    case "chunks_dur":
                        TimeSpan.TryParse(statusView.value, out chunkTime);
                        break;
                    case "items_dur": break;
                }

                yield return statusView;
            }

            yield return new StatusView {txt = "Total Chunks", value = totalChunks + ""};
            if (default != chunkTime && finishedChunks > 0)
            {
                var r = Convert.ToInt64((totalChunks - finishedChunks) * chunkTime.TotalMilliseconds / finishedChunks);
                yield return new StatusView {txt = "Remaining Chunks Time", value = TimeSpan.FromMilliseconds(r).ToString()};
                if (r > 0)
                    yield return new StatusView
                        {txt = "Est. Chunks Finish", value = DateTime.Now.AddMilliseconds(r).ToString()};
                yield return new StatusView
                {
                    txt   = "Chunks Per Hour",
                    value = (finishedChunks / chunkTime.TotalHours).ToString()
                };
                yield return new StatusView
                {
                    txt   = "Chunks Per Minute",
                    value = (finishedChunks / chunkTime.TotalMinutes).ToString()
                };
            }
        }
    }
}