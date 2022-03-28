using CPRDGOLD.loaders;
using CPRDGOLD.mappers;
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
        public static void CareSiteMap()
        {
            CareSite.InsertSets();
        }

        public static void Run()
        {
            InitializeLoaders();
            int[] ids = { 0 };
            foreach (int id in ids) ChunkBased(new Chunk() { ordinal = id });
        }

        private static void ChunkBased(Chunk chunk)
        {
            Log.Info("Starting for Chunk entries...");
          //  ConditionOccurrence.InsertSets();
          //  CareSite.InsertSets();
            Log.Info("Finished Chunk entries!");
        }

        private static void InitializeLoaders()
        {
            Log.Info("Starting Full Initializers...");
            List<Action> actions = new List<Action>{
              // ()=>SourceToSourceLoader.Initialize(),
             //   ()=>SourceToStandardLoader.Initialize(),
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
