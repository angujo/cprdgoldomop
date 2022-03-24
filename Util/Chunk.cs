using System;
using System.Collections.Generic;

namespace Util
{
    public class Chunk
    {
        public string tableName = "_chunk";
        public int ordinal = 0;
        public string column = "patient_id";
        public string ordinalColumn = "ordinal";
        public string relationColumn = "patid";
        public string relationTableName;
        public dynamic dbms;

        protected List<Action> cleaners = new List<Action>();

        public void AddCleaner(Action clean) { cleaners.Add(clean); }

        public void Clean() { foreach (Action action in cleaners) { action(); } cleaners.Clear(); }
    }
}
