﻿using CPRDGOLD.loaders;
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

namespace CPRDGOLD
{
    public static class CPRDGOLDMap
    {
        private static AppDBMS appDBMS;

        public static async void Run(Action<bool> isUp)
        {
            Log.Info("Checking Workload to proccess...");
            appDBMS = new AppDBMS();
            if (null == appDBMS.workload)
            {
                Log.Info("No Workload to proccess...");
                return;
            }
            _ = Task.Run(() =>
              {
                  Log.Info("We are in a workload proccess...");
                  try
                  {
                      isUp(true);

                      appDBMS.StartQueue();

                      appDBMS.CleanUpChunks();

                      Initiate();

                      appDBMS.StopQueue();

                      //Cleanup again to reset incomplete workload and chunks
                      appDBMS.CleanUpChunks();
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
               try
               {
                   chunk.Start();

                   StemTableUsers(chunk);
                   ChunkBased(chunk);

                   chunk.Implemented();
               }
               catch (Exception ex)
               {
                   chunk.Stop(ex);
               }
               finally
               {
                   chunk.Clean();
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
            StemTableMerger.Prepare(chunk);

            Log.Info("StemTable Loaded!");
            Log.Info("StemTable Start Stats:");
            var stemA = StemTableMerger.GetData(chunk).OrderBy(dt => dt.domain_id).GroupBy(dt => dt.domain_id).ToDictionary(kv => kv.Key, kv => kv.Count());
            foreach (var s in stemA) Log.Info($"{s.Key} = {s.Value}");
            Log.Info("StemTable END Stats:");

            Log.Info("Start StemTable entries!");
            List<Action> actions = new List<Action>
            {
                () => chunk.Implement(LoadType.CONDITIONOCCURRENCE, () => ConditionOccurrence.InsertSets(chunk)),
                () => chunk.Implement(LoadType.DEVICEEXPOSURE, () => DeviceExposure.InsertSets(chunk)),
                () => chunk.Implement(LoadType.SPECIMEN, () => Specimen.InsertSets(chunk)),
                () => chunk.Implement(LoadType.OBSERVATION, () => Observation.InsertSets(chunk)),
                () => chunk.Implement(LoadType.DRUGEXPOSURE, () => DrugExposure.InsertSets(chunk)),
                () => chunk.Implement(LoadType.MEASUREMENT, () => Measurement.InsertSets(chunk)),
                () => chunk.Implement(LoadType.PROCEDUREEXPOSURE, () => ProcedureOccurrence.InsertSets(chunk)),
            };
            Parallel.ForEach(actions, action => action());
            Log.Info("Finished StemTable entries!");
        }

        //Only runs once in the life of the app
        private static void SingleRuns()
        {
            List<Action> actions = new List<Action>
            {
                () => Chunk.SUImplement(LoadType.PROVIDER, () => Provider.InsertSets(null)),
                () => Chunk.SUImplement(LoadType.CARESITE, () => CareSite.InsertSets(null)),
                () => Chunk.SUImplement(LoadType.LOCATION, () => Location.InsertSets(null)),
                () => Chunk.SUImplement(LoadType.CDMSOURCE, () => CdmSource.InsertSets(null)),
                () => Chunk.SUImplement(LoadType.COHORTDEFINITION, () => CohortDefinition.InsertSets(null))
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
    }
}
