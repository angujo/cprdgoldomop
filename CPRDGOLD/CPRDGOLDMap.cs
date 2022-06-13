using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRDGOLD.loaders;
using CPRDGOLD.mappers;
using CPRDGOLD.mergers;
using CPRDGOLD.post;
using CPRDGOLD.setups;
using DBMS;
using DBMS.models;
using Util;

namespace CPRDGOLD
{
    public static class CPRDGOLDMap
    {
        private static AppDBMS appDBMS;

        public static void Run(Action<long, bool> isUp)
        {
            Log.Warning("Checking Workload to process...");
            appDBMS = new AppDBMS();
            if (null == appDBMS.workload)
            {
                Log.Warning("No Workload to process...");
                return;
            }

            Task.Run(() =>
            {
                Log.Info("We are in a workload process...");
                try
                {
                    // We need to commit that we are working
                    // If we don't commit the next service check will result to chaos!
                    isUp(appDBMS.workload.Id, true);
                    //Ensure we have all schemas
                    DB.FetchSchemas(appDBMS.workload.Id);

                    // Now we roll...

                    Chunk.WorkLoadId = appDBMS.workload.Id;

                    appDBMS.StartQueue();

                    ForChunkSetup();

                    RunChunks();

                    // Prepare Post CdmTimers
                    Chunk.ForPost();
                    Chunk.ForIndexes();

                    if (appDBMS.workload.Chunksloaded)
                    {
                        PostSetup();
                        appDBMS.CleanupNonChunk(-3, "post_chunk_loaded");

                        PostIndices();
                        appDBMS.CleanupNonChunk(-2, "indices_loaded");

                        if (appDBMS.workload.Chunksloaded && appDBMS.workload.Chunkssetup &&
                            appDBMS.workload.post_chunk_loaded && appDBMS.workload.indices_loaded)
                        {
                            appDBMS.workload.Cdmprocessed = true;
                            appDBMS.workload.Save();
                        }
                    }

                    appDBMS.StopQueue();
                }
                catch (Exception ex)
                {
                    Log.Error($"WorkLoad Error: {appDBMS.workload.Id}");
                    Log.Error(ex);
                    appDBMS.StopQueue(ex);
                    throw;
                }
                finally
                {
                    isUp(0, false);
                }

                Log.Info("We are Done...");
            });
        }

        private static void ForChunkSetup()
        {
            Setups();

            InitializeLoaders();

            SingleRuns();

            appDBMS.CleanupNonChunk(-1, "chunksSetup");
        }

        private static void RunChunks()
        {
            while (true)
            {
                if (!appDBMS.workload.Chunkssetup)
                {
                    appDBMS.workload.Chunksloaded = false;
                    return;
                }

                appDBMS.CleanUpChunks();
                var ordinals = appDBMS.ChunkOrdinals().ToArray();

                Parallel.ForEach(ordinals, new ParallelOptions {MaxDegreeOfParallelism = appDBMS.workload.Maxparallels, CancellationToken = Runner.Token}, chunkOrdinal =>
                {
                    var chunk = new Chunk {ordinal = chunkOrdinal}; // 12 };// ordinals[new Random().Next(0, ordinals.Length)] };

                    //Initialize all data loader for the chunk.
                    try
                    {
                        chunk.Start();

                        if (chunk.Implementable(LoadType.DEATH, LoadType.PERSON)) chunk.InitLoader(ChunkLoadType.ACTIVE_PATIENT, ActivePatientLoader.Initialize(chunk));
                        if (chunk.Implementable(LoadType.VISITDETAIL, LoadType.VISIT_OCCURRENCE)) chunk.InitLoader(ChunkLoadType.CONSULTATION, ConsultationLoader.Initialize(chunk));

                        if (chunk.ImplementableStemTable())
                        {
                            chunk.InitLoader(ChunkLoadType.IMMUNISATION, ImmunisationLoader.Initialize(chunk))
                                 .InitLoader(ChunkLoadType.THERAPY, TherapyLoader.Initialize(chunk))
                                 .InitLoader(ChunkLoadType.ADDITIONAL, AdditionalLoader.Initialize(chunk))
                                 .InitLoader(ChunkLoadType.TEST, TestLoader.Initialize(chunk))
                                 .InitLoader(ChunkLoadType.REFERRAL, ReferralLoader.Initialize(chunk))
                                 .InitLoader(ChunkLoadType.CLINICAL, ClinicalLoader.Initialize(chunk));
                        }

                        if (chunk.Implementable(LoadType.OBSERVATIONPERIOD)) chunk.InitLoader(ChunkLoadType.PATIENT, PatientLoader.Initialize(chunk));

                        var actions = new List<Action> {() => StemTableUsers(chunk), () => ChunkBased(chunk),};
                        Parallel.ForEach(actions, Runner.ParallelOptions, action => action());

                        chunk.Implemented();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                        chunk.Stop(ex);
                    }
                });

                appDBMS.CleanUpChunks();
                if (!appDBMS.workload.Chunksloaded) continue;
                break;
            }
        }

        private static void ChunkBased(Chunk chunk)
        {
            chunk.Log.Info("Starting for Chunk entries...");
            var actions = new List<Action>
            {
                () => chunk.Implement(LoadType.PERSON, () => Person.InsertSets(chunk)),
                () => chunk.Implement(LoadType.OBSERVATIONPERIOD, () => ObservationPeriod.InsertSets(chunk)),
                () => chunk.Implement(LoadType.VISITDETAIL, () => VisitDetail.InsertSets(chunk)),
                () => chunk.Implement(LoadType.VISIT_OCCURRENCE, () => VisitOccurrence.InsertSets(chunk)),
                () => chunk.Implement(LoadType.DEATH, () => Death.InsertSets(chunk)),
            };
            Parallel.ForEach(actions, Runner.ParallelOptions, action => action());
            chunk.Log.Info("Finished Chunk entries!");
        }

        //Are all dependant on the StemTable virtual existence
        private static void StemTableUsers(Chunk chunk)
        {
            //It is cheaper to check than to load stem tables and not use
            if (!chunk.Implementable(LoadType.CONDITIONOCCURRENCE, LoadType.DEVICEEXPOSURE, LoadType.SPECIMEN,
                                     LoadType.OBSERVATION, LoadType.DRUGEXPOSURE, LoadType.MEASUREMENT,
                                     LoadType.PROCEDUREEXPOSURE)) return;
            var stemTable = StemTableMerger.Prepare(chunk);

            chunk.Log.Info("StemTable Loaded!");
            chunk.Log.Info("StemTable Start Stats:");
            foreach (var s in stemTable.GetData().Where(sd => null != sd.domain_id && default != sd.domain_id)
                                       .OrderBy(dt => dt.domain_id).GroupBy(dt => dt.domain_id)
                                       .ToDictionary(kv => kv.Key, kv => kv.Count()))
                chunk.Log.Info($"{s.Key} = {s.Value}");
            chunk.Log.Info("StemTable END Stats:");

            chunk.Log.Info("Start StemTable entries!");
            var actions = new List<Action>
            {
                () => chunk.Implement(LoadType.CONDITIONOCCURRENCE,
                                      () => ConditionOccurrence.InsertSets(chunk, stemTable)),
                () => chunk.Implement(LoadType.DEVICEEXPOSURE, () => DeviceExposure.InsertSets(chunk, stemTable)),
                () => chunk.Implement(LoadType.SPECIMEN, () => Specimen.InsertSets(chunk, stemTable)),
                () => chunk.Implement(LoadType.OBSERVATION, () => Observation.InsertSets(chunk, stemTable)),
                () => chunk.Implement(LoadType.DRUGEXPOSURE, () => DrugExposure.InsertSets(chunk, stemTable)),
                () => chunk.Implement(LoadType.MEASUREMENT, () => Measurement.InsertSets(chunk, stemTable)),
                () => chunk.Implement(LoadType.PROCEDUREEXPOSURE,
                                      () => ProcedureOccurrence.InsertSets(chunk, stemTable)),
            };
            Parallel.ForEach(actions, Runner.ParallelOptions, action => action());
            chunk.Log.Info("Finished StemTable entries!");
        }

        //Only runs once in the life of the app
        private static void SingleRuns()
        {
            var actions = new List<Action>
            {
                () => Chunk.SUImplement(LoadType.PROVIDER, () => Provider.InsertSets()),
                () => Chunk.SUImplement(LoadType.CARESITE, () => CareSite.InsertSets()),
                () => Chunk.SUImplement(LoadType.LOCATION, () => Location.InsertSets()),
                () => Chunk.SUImplement(LoadType.CDMSOURCE, () => CdmSource.InsertSets()),
                () => Chunk.SUImplement(LoadType.COHORTDEFINITION, () => CohortDefinition.InsertSets())
            };

            Parallel.ForEach(actions, Runner.ParallelOptions, action => action());
        }

        private static void Setups()
        {
            Chunk.ForSetup();
            Chunk.SUImplement(LoadType.CREATETABLES, () =>
            {
                var tables = new TablesSetup();
                tables.Create();
                tables.Run();
            });

            Chunk.SUImplement(LoadType.CHUNKSETUP, () =>
            {
                var chunks = new ChunkSetup();
                chunks.Create();
                chunks.ChunkLoad(appDBMS.workload.Chunksize);
            });

            Chunk.SUImplement(LoadType.CHUNKLOAD, () =>
            {
                var chunks = new ChunkSetup();
                if (appDBMS.workload.Id != default) chunks.ChunkOrdinate(appDBMS.workload.Id);
            });

            // From below we can run parallel, they are independent of each other
            var actions = new List<Action>
            {
                () =>
                    Chunk.SUImplement(LoadType.DAY_SUPPLY_DECODE_SETUP, () =>
                    {
                        var decodes = new DaySupplyDecodeSetup();
                        decodes.Create();
                        decodes.Run();
                    }),


                () =>
                    Chunk.SUImplement(LoadType.DAYSUPPLYMODESETUP, () =>
                    {
                        var modes = new DaySupplyModeSetup();
                        modes.Create();
                        modes.Run();
                    }),


                () =>
                    Chunk.SUImplement(LoadType.SOURCETOSOURCE, () =>
                    {
                        var source = new SourceToSourceSetup();
                        source.Create();
                        source.Run();
                    }),


                () =>
                    Chunk.SUImplement(LoadType.SOURCETOSTANDARD, () =>
                    {
                        var standard = new SourceToStandardSetup();
                        standard.Create();
                        standard.Run();
                    })
            };

            Parallel.ForEach(actions, Runner.ParallelOptions, action => action());
        }

        private static void InitializeLoaders()
        {
            Log.Info("Starting Full Initializers...");
            var actions = new List<Action>
            {
                CommonDosageLoader.Initialize,
                ConceptLoader.Initialize,
                DaySupplyDecodeLoader.Initialize,
                DaySupplyModeLoader.Initialize,
                EntityLoader.Initialize,
                LookupLoader.Initialize,
                MedicalLoader.Initialize,
                PracticeLoader.Initialize,
                ProductLoader.Initialize,
                ScoreMethodLoader.Initialize,
                SourceToConceptMapLoader.Initialize,
                StaffLoader.Initialize,
            };
            Parallel.ForEach(actions, Runner.ParallelOptions, action => action());
            Log.Info("Finished Full Initializers");
        }

        private static void PostSetup()
        {
            // Avoid conflict in the parallel universe.
            // Initialize static var
            Chunk.ForPost();
            Log.Info("Starting Post Chunk Setup...");
            var actions = new List<Action>
            {
                () => Chunk.PostImplement(LoadType.DRUGERA, PostMap.Implement<PostDrugEra>),
                () => Chunk.PostImplement(LoadType.CONDITIONERA, PostMap.Implement<PostConditionEra>),
                // () =>Chunk.PostImplement(LoadType.DOSE_ERA, () =>(new PostDoseEra()).Implement()),
                () => Chunk.PostImplement(LoadType.P_VISIT_DETAIL, PostMap.Implement<PostVisitDetail>),
            };

            Parallel.ForEach(actions, Runner.ParallelOptions, action => action());
            Log.Info("Finished Post Chunk Setup");
        }

        private static void PostIndices()
        {
            // Still avoiding killing our replica in the parallel universe
            // Ensure there's only one of us
            Chunk.ForIndexes();

            Log.Info("Starting Indices Setup...");
            var actions = new List<Action>
            {
                //--------OMOP CDM Tables--------------
                () => Chunk.IDXImplement(LoadType.IDX_CARE_SITE, PostIndex.Implement<CareSite>),
                () => Chunk.IDXImplement(LoadType.IDX_CDM_SOURCE, PostIndex.Implement<CdmSource>),
                () => Chunk.IDXImplement(LoadType.IDX_COHORT, PostIndex.Implement<Cohort>),
                () => Chunk.IDXImplement(LoadType.IDX_COHORT_DEFINITION, PostIndex.Implement<CohortDefinition>),
                () => Chunk.IDXImplement(LoadType.IDX_COHORT_ATTRIBUTE, PostIndex.Implement<CohortAttribute>),
                () => Chunk.IDXImplement(LoadType.IDX_CONDITION_ERA, PostIndex.Implement<ConditionEra>),
                () => Chunk.IDXImplement(LoadType.IDX_CONDITION_OCCURRENCE, PostIndex.Implement<ConditionOccurrence>),
                () => Chunk.IDXImplement(LoadType.IDX_COST, PostIndex.Implement<Cost>),
                () => Chunk.IDXImplement(LoadType.IDX_DEATH, PostIndex.Implement<Death>),
                () => Chunk.IDXImplement(LoadType.IDX_DEVICE_EXPOSURE, PostIndex.Implement<DeviceExposure>),
                () => Chunk.IDXImplement(LoadType.IDX_DOSE_ERA, () => PostIndex.Implement("dose-era")),
                () => Chunk.IDXImplement(LoadType.IDX_DRUG_ERA, PostIndex.Implement<DrugEra>),
                () => Chunk.IDXImplement(LoadType.IDX_DRUG_EXPOSURE, PostIndex.Implement<DrugExposure>),
                () => Chunk.IDXImplement(LoadType.IDX_LOCATION, PostIndex.Implement<Location>),
                () => Chunk.IDXImplement(LoadType.IDX_MEASUREMENT, PostIndex.Implement<Measurement>),
                () => Chunk.IDXImplement(LoadType.IDX_NOTE, PostIndex.Implement<Note>),
                () => Chunk.IDXImplement(LoadType.IDX_NOTE_NLP, () => PostIndex.Implement("note-nlp")),
                () => Chunk.IDXImplement(LoadType.IDX_OBSERVATION, PostIndex.Implement<Observation>),
                () => Chunk.IDXImplement(LoadType.IDX_OBSERVATION_PERIOD, PostIndex.Implement<ObservationPeriod>),
                () => Chunk.IDXImplement(LoadType.IDX_PAYER_PLAN_PERIOD, PostIndex.Implement<PayerPlanPeriod>),
                () => Chunk.IDXImplement(LoadType.IDX_PERSON, PostIndex.Implement<Person>),
                () => Chunk.IDXImplement(LoadType.IDX_PROCEDURE_OCCURRENCE, PostIndex.Implement<ProcedureOccurrence>),
                () => Chunk.IDXImplement(LoadType.IDX_PROVIDER, PostIndex.Implement<Provider>),
                () => Chunk.IDXImplement(LoadType.IDX_SPECIMEN, PostIndex.Implement<Specimen>),
                () => Chunk.IDXImplement(LoadType.IDX_VISIT_DETAIL, PostIndex.Implement<VisitDetail>),
                () => Chunk.IDXImplement(LoadType.IDX_VISIT_OCCURRENCE, PostIndex.Implement<VisitOccurrence>),
                // PostIndex.Implement<FactRelationship>,

                // ----- Vocabulary---------
                // Vocabularies are already indexed
                // () => Chunk.IDXImplement(LoadType.IDX_CONCEPT, PostIndex.Implement<Concept>),
                // () => Chunk.IDXImplement(LoadType.IDX_CONCEPT_ANCESTOR, () => PostIndex.Implement("concept-ancestor")),
                // () => Chunk.IDXImplement(LoadType.IDX_DRUG_STRENGTH, () => PostIndex.Implement("drug-strength")),
                // () => Chunk.IDXImplement(LoadType.IDX_CONCEPT_CLASS, () => PostIndex.Implement("concept-class")),
                // () => Chunk.IDXImplement(LoadType.IDX_CONCEPT_RELATIONSHIP, () => PostIndex.Implement("concept-relationship")),
                // () => Chunk.IDXImplement(LoadType.IDX_CONCEPT_SYNONYM, () => PostIndex.Implement("concept-synonym")),
                // () => Chunk.IDXImplement(LoadType.IDX_VOCABULARY, () => PostIndex.Implement("vocabulary")),
                // () => Chunk.IDXImplement(LoadType.IDX_DOMAIN, () => PostIndex.Implement("domain")),
                // () => Chunk.IDXImplement(LoadType.IDX_RELATIONSHIP, () => PostIndex.Implement("relationship")),
            };
            Parallel.ForEach(
                actions,
                new ParallelOptions {MaxDegreeOfParallelism = 5, CancellationToken = Runner.Token},
                action => action());
            Log.Info("Finished Indices Setup");
        }
    }
}