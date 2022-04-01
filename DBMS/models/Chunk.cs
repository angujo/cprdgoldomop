using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace DBMS.models
{
    public class Chunk
    {
        private static Chunk _setup;
        public string tableName = "_chunk";
        public int ordinal = 0;
        public static long WorkLoadId = 0;
        public string column = "patient_id";
        public string ordinalColumn = "ordinal";
        public string relationColumn = "patid";
        public string relationTableName { get; set; }
        private Chunktimer timer;
        public dynamic dbms { get; set; }

        public string[] LoadedNames { get { return Loads.Keys.Select(k => k.GetStringValue()).ToArray(); } }

        protected Dictionary<Util.LoadType, Cdmtimer> Loads = new Dictionary<Util.LoadType, Cdmtimer>();

        protected List<Action> cleaners = new List<Action>();

        public Chunk() { }

        public void AddCleaner(Action clean) { cleaners.Add(clean); }

        public void Clean() { foreach (Action action in cleaners) { action(); } cleaners.Clear(); }

        public Cdmtimer GetLoad(LoadType ltype) => Loads.ContainsKey(ltype) ? Loads[ltype] : null;

        private Chunktimer GetTimer() => timer ?? (timer = DB.Internal.Load<Chunktimer>(new { chunkid = ordinal, workloadid = WorkLoadId }));

        public void Start()
        {
            SetupLoads();
            CommitLoads();
            if (ordinal >= 0) GetTimer().Start();
        }

        public void Stop(Exception ex = null)
        {
            if (ordinal >= 0) GetTimer().Stop(ex);
        }

        public void Implemented()
        {
            if (ordinal >= 0) GetTimer().Implemented();
        }

        private void SetupLoads()
        {
            var once = new LoadType[] {
                LoadType.PROVIDER, LoadType.CARESITE, LoadType.LOCATION, LoadType.CDMSOURCE, LoadType.COHORTDEFINITION, LoadType.DAYSUPPLYDECODESETUP, LoadType.DAYSUPPLYMODESETUP,
                LoadType.SOURCETOSOURCE, LoadType.SOURCETOSTANDARD, LoadType.CREATETABLES,LoadType.CHUNKSETUP,LoadType.CHUNKLOAD };
            LoadType[] types = (0 > ordinal ? once : Enum.GetValues(typeof(LoadType)).Cast<LoadType>().Where(lt => !once.Contains(lt))).ToArray();
            string[] names = types.Select(lt => lt.GetStringValue()).ToArray();
            Loads = DB.Internal.GetAll<Cdmtimer>("WHERE workloadid = @WorkLoadId AND chunkid = @ChunkId AND name = ANY(@Name)", new { WorkLoadId = WorkLoadId, ChunkId = ordinal, Name = names }).ToDictionary(ct => LoadTypeFromName(ct.Name), ct => ct);

            var missingTypes = types.Where(name => !Loads.ContainsKey(name));
            foreach (var lkey in missingTypes) Loads[lkey] = new Cdmtimer { WorkLoadId = WorkLoadId, Name = lkey.GetStringValue(), LoadType = lkey, ChunkId = ordinal, Status = Status.SCHEDULED };
        }

        private void CommitLoads()
        {
            foreach (var load in Loads.ToList().Select(kv => kv.Value))
            {
                load.Save();
            }
        }

        public void Implement(LoadType ltype, Action impl)
        {
            Loads[ltype].Implement(impl);
        }

        private LoadType LoadTypeFromName(string name)
        {
            return Enum.GetValues(typeof(LoadType)).Cast<LoadType>().FirstOrDefault(lt => lt.GetStringValue().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static Chunk ForSetup()
        {
            if (null != _setup) return _setup;
            _setup = new Chunk { ordinal = -1 };
            _setup.Start();
            return _setup;
        }

        public bool Implementable(params LoadType[] ltypes)
        {
            foreach (var ltype in ltypes) if (GetLoad(ltype).IsPending) return true;
            return false;
        }

        public static Cdmtimer SULoad(LoadType ltype) => ForSetup().GetLoad(ltype);

        public static void SUImplement(LoadType ltype, Action impl)
        {
            SULoad(ltype).Implement(() =>
            {
                Log.Info($"Starting implementation of {ltype.GetStringValue()}");
                impl();
                Log.Info($"Finished implementation of {ltype.GetStringValue()}");
            });
        }
    }
}
