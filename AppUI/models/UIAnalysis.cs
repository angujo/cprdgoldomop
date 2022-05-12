using System;
using System.Windows.Forms;
using DBMS;
using DBMS.models;

namespace AppUI.models
{
    public class UIAnalysis : UIModel
    {
        public static void LoadAnalysis(Action<ListViewItem> action)
        {
            var lists = DB.Internal.GetAll<ChunksAnalysis>();
            foreach (var analysis in lists)
            {
                var lv = new ListViewItem(analysis.descr);
                lv.SubItems.Add(analysis.value + "");
                action(lv);
            }
        }
    }
}