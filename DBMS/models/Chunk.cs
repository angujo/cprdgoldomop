using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace DBMS.models
{
    public class Chunk
    {
        public string tableName = "_chunk";
        public int ordinal = 0;
        public long WorkLoadId = 0;
        public string column = "patient_id";
        public string ordinalColumn = "ordinal";
        public string relationColumn = "patid";
        public string relationTableName;
        public dynamic dbms { get; set; }

        public string[] LoadedNames { get { return Loads.Keys.Select(k => k.GetStringValue()).ToArray(); } }

        protected Dictionary<Util.LoadType, CDMTimer> Loads = new Dictionary<Util.LoadType, CDMTimer>();

        protected List<Action> cleaners = new List<Action>();

        public void AddCleaner(Action clean) { cleaners.Add(clean); }

        public void Clean() { foreach (Action action in cleaners) { action(); } cleaners.Clear(); }

        public CDMTimer GetLoad(LoadType ltype) => Loads.ContainsKey(ltype) ? Loads[ltype] : null;

        public void SetupLoads()
        {
            var once = new LoadType[] { LoadType.PROVIDER, LoadType.CARESITE, LoadType.LOCATION, LoadType.CDMSOURCE, LoadType.COHORTDEFINITION, LoadType.DAYSUPPLYDECODESETUP, LoadType.DAYSUPPLYMODESETUP,
                LoadType.SOURCETOSOURCE, LoadType.SOURCETOSTANDARD, LoadType.CREATETABLES, };
            LoadType[] types = (0 > ordinal ? once : Enum.GetValues(typeof(LoadType)).Cast<LoadType>().Where(lt => !once.Contains(lt))).ToArray();
            string[] names = types.Select(lt => lt.GetStringValue()).ToArray();
            Loads = DB.Internal.GetAll<CDMTimer>(new { WorkLoadId = WorkLoadId, ChunkId = ordinal, Name = names }).ToDictionary(ct => LoadTypeFromName(ct.Name), ct => ct);

            var missingTypes = types.Where(name => !Loads.ContainsKey(name));
            foreach (var lkey in missingTypes) Loads[lkey] = new CDMTimer { WorkLoadId = WorkLoadId, Name = lkey.GetStringValue(), LoadType = lkey, ChunkId = ordinal, Status = Status.SCHEDULED };
        }

        public void CommitLoads()
        {
            foreach (var load in Loads) load.Value.Save();
        }

        private LoadType LoadTypeFromName(string name)
        {
            return Enum.GetValues(typeof(LoadType)).Cast<LoadType>().FirstOrDefault(lt => lt.GetStringValue().Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
