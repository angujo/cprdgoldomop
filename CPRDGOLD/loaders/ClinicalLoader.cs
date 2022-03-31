using CPRDGOLD.models;
using DBMS.models;
using System.Collections.Generic;
using System.Linq;

namespace CPRDGOLD.loaders
{
    internal class ClinicalLoader : ChunkLoader<ClinicalLoader, Clinical>
    {
        public ClinicalLoader() : base("clinical") { }
        public ClinicalLoader(Chunk chunk) : base("clinical", chunk) { }

        public void ChunkData(IEnumerable<Clinical> items = null)
        {
            ParallelChunk(item => new long[] { item.patid, item.adid }.Select(k=>$"{k}").ToArray(), items);
        }

        public static void Prepare(Chunk chunk) => GetMe(chunk);

        public static Clinical ByPatientAdId(Chunk chunk, int adid, long patid)=>ChunkValue(chunk, patid.ToString(), adid.ToString());
    }
}
