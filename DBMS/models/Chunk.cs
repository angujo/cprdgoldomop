using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace DBMS.models
{
    public class Chunk
    {
        private static Chunk _setup;
        private static Chunk _index;
        private static Chunk _post;

        private static readonly LoadType[] POST_LOAD_TYPES =
            {LoadType.CONDITIONERA, LoadType.DRUGERA, LoadType.P_VISIT_DETAIL}; // LoadType.DOSE_ERA, //Disable for now

        private static readonly LoadType[] INDICES_LOAD_TYPES =
        {
            LoadType.IDX_CARE_SITE, LoadType.IDX_CDM_SOURCE, LoadType.IDX_COHORT_ATTRIBUTE,
            LoadType.IDX_COHORT_DEFINITION, LoadType.IDX_COHORT,
            LoadType.IDX_CONDITION_ERA, LoadType.IDX_CONDITION_OCCURRENCE, LoadType.IDX_COST,
            LoadType.IDX_DEATH, LoadType.IDX_DEVICE_EXPOSURE, LoadType.IDX_DOSE_ERA,
            LoadType.IDX_DRUG_ERA, LoadType.IDX_DRUG_EXPOSURE, LoadType.IDX_LOCATION, LoadType.IDX_MEASUREMENT,
            LoadType.IDX_NOTE_NLP,
            LoadType.IDX_NOTE, LoadType.IDX_OBSERVATION_PERIOD,
            LoadType.IDX_PAYER_PLAN_PERIOD, LoadType.IDX_PERSON, LoadType.IDX_PROCEDURE_OCCURRENCE,
            LoadType.IDX_PROVIDER, LoadType.IDX_SPECIMEN, LoadType.IDX_VISIT_DETAIL,
            LoadType.IDX_VISIT_OCCURRENCE, LoadType.IDX_OBSERVATION,
            // /** We disable below for now */
            // LoadType.IDX_CONCEPT_ANCESTOR, LoadType.IDX_CONCEPT_CLASS, LoadType.IDX_CONCEPT_RELATIONSHIP,
            // LoadType.IDX_CONCEPT_SYNONYM, LoadType.IDX_CONCEPT, LoadType.IDX_DOMAIN,LoadType.IDX_DRUG_STRENGTH,
            // LoadType.IDX_FACT_RELATIONSHIP, LoadType.IDX_RELATIONSHIP, LoadType.IDX_VOCABULARY,
        };

        private static readonly LoadType[] ONCE_LOAD_TYPES =
        {
            LoadType.PROVIDER, LoadType.CARESITE, LoadType.LOCATION, LoadType.CDMSOURCE, LoadType.COHORTDEFINITION,
            LoadType.DAY_SUPPLY_DECODE_SETUP, LoadType.DAYSUPPLYMODESETUP,
            LoadType.SOURCETOSOURCE, LoadType.SOURCETOSTANDARD, LoadType.CREATETABLES, LoadType.CHUNKSETUP,
            LoadType.CHUNKLOAD
        };

        private static LoadType[] CHUNK_LOAD_TYPES
        {
            get
            {
                var excludes = ONCE_LOAD_TYPES.Concat(POST_LOAD_TYPES).Concat(INDICES_LOAD_TYPES);
                return Enum.GetValues(typeof(LoadType)).Cast<LoadType>().Where(lt => !excludes.Contains(lt)).ToArray();
            }
        }

        public static long WorkLoadId = 0;

        public string tableName = "_chunk";

        public int ordinal
        {
            get => _ord;
            set
            {
                _ord = value;
                Log.SetChunkId(value);
            }
        }

        public  string                             column         = "patient_id";
        public  string                             ordinalColumn  = "ordinal";
        public  string                             relationColumn = "patid";
        public  string                             relationTableName { get; set; }
        private Chunktimer                         timer;
        public  dynamic                            dbms { get; set; }
        public  Dictionary<ChunkLoadType, dynamic> loaders = new Dictionary<ChunkLoadType, dynamic>();
        public  Log.Chunk                          Log;

        public string[] LoadedNames
        {
            get { return Loads.Keys.Select(k => k.GetStringValue()).ToArray(); }
        }

        protected Dictionary<Util.LoadType, Cdmtimer> Loads = new Dictionary<Util.LoadType, Cdmtimer>();

        protected List<Action> cleaners = new List<Action>();
        private   int          _ord;

        public Chunk()
        {
            Log = new Log.Chunk(ordinal);
        }

        public void AddCleaner(Action clean)
        {
            cleaners.Add(clean);
        }

        public void Clean()
        {
            foreach (Action action in cleaners)
            {
                action();
            }

            cleaners.Clear();
        }

        public Cdmtimer GetLoad(LoadType ltype) => Loads.ContainsKey(ltype) ? Loads[ltype] : null;

        private Chunktimer GetTimer() =>
            timer ?? (timer = DB.Internal.Load<Chunktimer>(new {chunkid = ordinal, workloadid = WorkLoadId}));

        public void Start()
        {
            DoSetup(CHUNK_LOAD_TYPES);
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

        private void DoSetup(LoadType[] types)
        {
            string[] names = types.Select(lt => lt.GetStringValue()).ToArray();
            Loads = DB.Internal
                      .GetAll<Cdmtimer>("WHERE workloadid = @WorkLoadId AND chunkid = @ChunkId AND name = ANY(@Name)",
                                        new {WorkLoadId = WorkLoadId, ChunkId = ordinal, Name = names})
                      .ToDictionary(ct => LoadTypeFromName(ct.Name), ct => ct);
            var missingTypes = types.Where(name => !Loads.ContainsKey(name));
            foreach (var lkey in missingTypes)
                Loads[lkey] = new Cdmtimer
                {
                    WorkLoadId = WorkLoadId, Name = lkey.GetStringValue(), LoadType = lkey, ChunkId = ordinal,
                    Status     = Status.SCHEDULED
                };
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
            return Enum.GetValues(typeof(LoadType)).Cast<LoadType>()
                       .FirstOrDefault(lt => lt.GetStringValue().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static Chunk ForSetup()
        {
            if (null != _setup) return _setup;
            _setup = new Chunk {ordinal = -1};
            _setup.DoSetup(ONCE_LOAD_TYPES);
            _setup.CommitLoads();
            return _setup;
        }

        public static Chunk ForIndexes()
        {
            if (null != _index) return _index;
            _index = new Chunk {ordinal = -2};
            _index.DoSetup(INDICES_LOAD_TYPES);
            _index.CommitLoads();
            return _index;
        }

        public static Chunk ForPost()
        {
            if (default != _post) return _post;
            _post = new Chunk {ordinal = -3};
            _post.DoSetup(POST_LOAD_TYPES);
            _post.CommitLoads();
            return _post;
        }

        public bool ImplementableStemTable()
        {
            return Implementable(LoadType.CONDITIONOCCURRENCE, LoadType.DEVICEEXPOSURE, LoadType.SPECIMEN,
                                 LoadType.OBSERVATION, LoadType.DRUGEXPOSURE, LoadType.MEASUREMENT,
                                 LoadType.PROCEDUREEXPOSURE);
        }

        public bool Implementable(params LoadType[] ltypes)
        {
            foreach (var ltype in ltypes)
                if ((bool) (GetLoad(ltype)?.IsPending))
                    return true;
            return false;
        }

        public static void PostImplement(LoadType ltype, Action impl)
        {
            ForPost()
                .GetLoad(ltype)
                .Implement(impl);
        }

        private static Cdmtimer SULoad(LoadType ltype) => ForSetup().GetLoad(ltype);
        private static Cdmtimer IDXLoad(LoadType ltype) => ForIndexes().GetLoad(ltype);

        public static void SUImplement(LoadType ltype, Action impl)
        {
            SULoad(ltype).Implement(impl);
        }

        public static void IDXImplement(LoadType ltype, Action impl)
        {
            if (!INDICES_LOAD_TYPES.Contains(ltype)) return;
            IDXLoad(ltype).Implement(impl);
        }

        public Chunk InitLoader(ChunkLoadType l, dynamic load)
        {
            if (ordinal < 0) return this;
            loaders[l] = load;
            return this;
        }

        public T GetLoader<T>(ChunkLoadType l)
        {
            return (T) loaders[l];
        }
    }

    public enum ChunkLoadType
    {
        ACTIVE_PATIENT,
        ADDITIONAL,
        CLINICAL,
        CONSULTATION,
        IMMUNISATION,
        PATIENT,
        REFERRAL,
        TEST,
        THERAPY,
    }
}