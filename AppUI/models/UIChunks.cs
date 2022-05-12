using System;
using System.Windows.Forms;
using DBMS;
using DBMS.models;
using Util;

namespace AppUI.models
{
    internal class UIChunks : UIModel
    {
        public void LoadChunks(Action<ListViewItem> action)
        {
            foreach (var chunktimer in DB.Internal.GetAll<Chunktimer>())
            {
                var lv = new ListViewItem(chunktimer.ChunkId + "");
                lv.SubItems.Add(chunktimer.StartTime?.ToString("yy-MMM-dd ddd HH:m:s"));
                lv.SubItems.Add(chunktimer.EndTime?.ToString("yy-MMM-dd ddd HH:m:s") );
                lv.SubItems.Add(null != chunktimer.StartTime
                                    ? chunktimer.EndTime?.Subtract((DateTime) chunktimer.StartTime).ToString()
                                    : "");
                lv.SubItems.Add(chunktimer.Status.GetStringValue());
                action(lv);
            }
        }
    }
}