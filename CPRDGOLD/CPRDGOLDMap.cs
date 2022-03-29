using CPRDGOLD.loaders;
using CPRDGOLD.mappers;
using CPRDGOLD.mergers;
using CPRDGOLD.setups;
using DBMS.models;
using DBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD
{
    public static class CPRDGOLDMap
    {
        public static void Run()
        {
            AppDBMS.Set();
            ///  InitializeLoaders();
            int[] ids = { 0 };
            foreach (int id in ids)
            {
                //  ChunkBased(new Chunk() { ordinal = id });
            }
        }

        private static void Tester()
        {
        }

        private static void ChunkBased(Chunk chunk)
        {
            Log.Info("Starting for Chunk entries...");
            Person.InsertSets(chunk);
            ObservationPeriod.InsertSets(chunk);
            VisitDetail.InsertSets(chunk);
            Death.InsertSets(chunk);
            Log.Info("Finished Chunk entries!");
        }

        //Are all dependant on the StemTable virtual existance
        private static void StemTableUsers(Chunk chunk)
        {
            StemTableMerger.Prepare(chunk);

            ConditionOccurrence.InsertSets(chunk);
            DeviceExposure.InsertSets(chunk);
            Specimen.InsertSets(chunk);
            Observation.InsertSets(chunk);
            DrugExposure.InsertSets(chunk);
            Measurement.InsertSets(chunk);
            ProcedureOccurrence.InsertSets(chunk);
        }

        //Only runs once in the life of the app
        private static void SingleRuns()
        {
            Provider.InsertSets(null);
            CareSite.InsertSets(null);
            Location.InsertSets(null);
            CdmSource.InsertSets(null);
            CohortDefinition.InsertSets(null);
        }

        private static void Setups()
        {
            var decodes = new DaySupplyDecodeSetup();
            var modes = new DaySupplyModeSetup();
            var source = new SourceToSourceSetup();
            var standard = new SourceToStandardSetup();
            var tables = new TablesSetup();

            decodes.Create();
            decodes.Run();

            modes.Create();
            modes.Run();

            source.Create();
            source.Run();

            standard.Create();
            standard.Run();

            tables.Create();
            tables.Run();
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
