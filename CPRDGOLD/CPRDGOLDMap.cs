using CPRDGOLD.loaders;
using CPRDGOLD.mappers;
using CPRDGOLD.mergers;
using CPRDGOLD.setups;
using DBMS.models;
using DBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;
using CPRDGOLD.post;

namespace CPRDGOLD
{
    public static class CPRDGOLDMap
    {
        private static AppDBMS appDBMS;

        public static void Run(Action<bool> isUp)
        {
            Log.Warning("Checking Workload to proccess...");
            appDBMS = new AppDBMS();
            if (null == appDBMS.workload)
            {
                Log.Warning("No Workload to proccess...");
                return;
            }
            Task.Run(() =>
             {
                 Log.Info("We are in a workload proccess...");
                 try
                 {
                     isUp(true);

                     appDBMS.StartQueue();

                     appDBMS.CleanUpChunks();

                     Initiate();

                     //Cleanup again to reset incomplete workload and chunks
                     appDBMS.CleanUpChunks();

                     //Reload WorkPlan with new status
                     appDBMS.ReloadWorkPlan();

                     if (appDBMS.workload.CdmProcessed && !appDBMS.workload.CdmLoaded)
                     {
                         appDBMS.workload.CdmProcessed = false;
                         appDBMS.workload.Save();
                         PostSetup();
                         //Cleanup again to close workplan, where possible
                         appDBMS.CleanUpChunks();
                         if (appDBMS.ReloadWorkPlan().CdmProcessed)
                         {
                             appDBMS.workload.CdmLoaded = true;
                             appDBMS.workload.Save();
                         }
                     }

                     appDBMS.StopQueue();
                 }
                 catch (Exception ex)
                 {
                     Log.Error(ex);
                     appDBMS.StopQueue(ex);
                     throw;
                 }
                 finally { isUp(false); }
                 Log.Info("We are Done...");
             });
        }

        private static void Initiate()
        {
            Chunk.WorkLoadId = (long)appDBMS.workload.Id;

            Setups();

            InitializeLoaders();

            SingleRuns();

            var ordinals = appDBMS.ChunkOrdinals().ToArray();

            Parallel.ForEach(ordinals, new ParallelOptions { MaxDegreeOfParallelism = appDBMS.workload.MaxParallels }, chunkOrdinal =>
            {
                Chunk chunk = new Chunk { ordinal = chunkOrdinal };// 12 };// ordinals[new Random().Next(0, ordinals.Length)] };

                //Initialize all data loader for the chunk.
                try
                {
                    chunk.Start();

                    if (chunk.Implementable(LoadType.DEATH, LoadType.PERSON)) chunk.InitLoader(ChunkLoadType.ACTIVE_PATIENT, ActivePatientLoader.Initialize(chunk));
                    if (chunk.Implementable(LoadType.VISITDETAIL, LoadType.VISITOCCURRENCE)) chunk.InitLoader(ChunkLoadType.CONSULTATION, ConsultationLoader.Initialize(chunk));

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

                    List<Action> actions = new List<Action>
                    {
                        () => StemTableUsers(chunk),
                        () => ChunkBased(chunk),
                    };
                    Parallel.ForEach(actions, action => action());

                    chunk.Implemented();
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    chunk.Stop(ex);
                }
            });
        }

        private static void ChunkBased(Chunk chunk)
        {
            Log.Info("Starting for Chunk entries...");
            List<Action> actions = new List<Action>
            {
                () =>chunk.Implement(LoadType.PERSON, () => Person.InsertSets(chunk)),
                () =>chunk.Implement(LoadType.OBSERVATIONPERIOD, () => ObservationPeriod.InsertSets(chunk)),
                () =>chunk.Implement(LoadType.VISITDETAIL, () => VisitDetail.InsertSets(chunk)),
                () =>chunk.Implement(LoadType.VISITOCCURRENCE, () => VisitOccurrence.InsertSets(chunk)),
                () =>chunk.Implement(LoadType.DEATH, () => Death.InsertSets(chunk)),
            };
            Parallel.ForEach(actions, action => action());
            Log.Info("Finished Chunk entries!");
        }

        //Are all dependant on the StemTable virtual existance
        private static void StemTableUsers(Chunk chunk)
        {
            //It is cheaper to check than to load stem tables and not use
            if (!chunk.Implementable(LoadType.CONDITIONOCCURRENCE, LoadType.DEVICEEXPOSURE, LoadType.SPECIMEN, LoadType.OBSERVATION, LoadType.DRUGEXPOSURE, LoadType.MEASUREMENT, LoadType.PROCEDUREEXPOSURE)) return;
            var stemTable = StemTableMerger.Prepare(chunk);

            Log.Info("StemTable Loaded!");
            Log.Info("StemTable Start Stats:");
            foreach (var s in stemTable.GetData().Where(sd => null != sd.domain_id && default != sd.domain_id).OrderBy(dt => dt.domain_id).GroupBy(dt => dt.domain_id).ToDictionary(kv => kv.Key, kv => kv.Count()))
                Log.Info($"{s.Key} = {s.Value}");
            Log.Info("StemTable END Stats:");

            Log.Info("Start StemTable entries!");
            List<Action> actions = new List<Action>
            {
                () => chunk.Implement(LoadType.CONDITIONOCCURRENCE, () => ConditionOccurrence.InsertSets(chunk,stemTable)),
                () => chunk.Implement(LoadType.DEVICEEXPOSURE, () => DeviceExposure.InsertSets(chunk,stemTable)),
                () => chunk.Implement(LoadType.SPECIMEN, () => Specimen.InsertSets(chunk,stemTable)),
                () => chunk.Implement(LoadType.OBSERVATION, () => Observation.InsertSets(chunk,stemTable)),
                () => chunk.Implement(LoadType.DRUGEXPOSURE, () => DrugExposure.InsertSets(chunk,stemTable)),
                () => chunk.Implement(LoadType.MEASUREMENT, () => Measurement.InsertSets(chunk,stemTable)),
                () => chunk.Implement(LoadType.PROCEDUREEXPOSURE, () => ProcedureOccurrence.InsertSets(chunk,stemTable)),
            };
            Parallel.ForEach(actions, action => action());
            Log.Info("Finished StemTable entries!");
        }

        //Only runs once in the life of the app
        private static void SingleRuns()
        {
            List<Action> actions = new List<Action>
            {
                () => Chunk.SUImplement(LoadType.PROVIDER, () => Provider.InsertSets()),
                () => Chunk.SUImplement(LoadType.CARESITE, () => CareSite.InsertSets()),
                () => Chunk.SUImplement(LoadType.LOCATION, () => Location.InsertSets()),
                () => Chunk.SUImplement(LoadType.CDMSOURCE, () => CdmSource.InsertSets()),
                () => Chunk.SUImplement(LoadType.COHORTDEFINITION, () => CohortDefinition.InsertSets())
            };

            Parallel.ForEach(actions, action => action());
        }

        private static void Setups()
        {
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
                chunks.ChunkLoad(appDBMS.workload.ChunkSize);
            });

            Chunk.SUImplement(LoadType.CHUNKLOAD, () =>
            {
                var chunks = new ChunkSetup();
                chunks.ChunkOrdinate((long)appDBMS.workload.Id);
            });

            //From below we can run parallel, they are independent of each other
            List<Action> actions = new List<Action>
            {
                () =>
                Chunk.SUImplement(LoadType.DAYSUPPLYDECODESETUP, () =>
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

            Parallel.ForEach(actions, action => action());
        }

        private static void InitializeLoaders()
        {
            Log.Info("Starting Full Initializers...");
            List<Action> actions = new List<Action>{
                ()=>CommonDosageLoader.Initialize(),
                ()=>ConceptLoader.Initialize(),
                ()=>DaySupplyDecodeLoader.Initialize(),
                ()=>DaySupplyModeLoader.Initialize(),
                ()=>EntityLoader.Initialize(),
                ()=>LookupLoader.Initialize(),
                ()=>MedicalLoader.Initialize(),
                ()=>PracticeLoader.Initialize(),
                ()=>ProductLoader.Initialize(),
                ()=>ScoreMethodLoader.Initialize(),
                ()=>SourceToConceptMapLoader.Initialize(),
                ()=>StaffLoader.Initialize(),
            };
            Parallel.ForEach(actions, action => action());
            Log.Info("Finished Full Initializers");
        }

        private static void PostSetup()
        {
            // Avoid conflict in the parallel universe.
            // Initialize static var
            Chunk.ForPost();
            List<Action> actions = new List<Action>
            {
                () =>Chunk.PostImplement(LoadType.DRUGERA, () =>PostMap.Implement<PostDrugEra>()),
                () =>Chunk.PostImplement(LoadType.CONDITIONERA, () =>PostMap.Implement<PostConditionEra>()),
                // () =>Chunk.PostImplement(LoadType.DOSE_ERA, () =>(new PostDoseEra()).Implement()),
                () =>Chunk.PostImplement(LoadType.P_VISIT_DETAIL, () =>PostMap.Implement<PostVisitDetail>()),
            };

            Parallel.ForEach(actions, action => action());
        }
    }
}
