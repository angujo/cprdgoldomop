using System.Collections.Generic;
using System.Linq;
using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.loaders
{
    internal class ClinicalLoader : ChunkLoader<ClinicalLoader, Clinical>
    {
        public ClinicalLoader() : base("clinical")
        {
        }

        public ClinicalLoader(Chunk chunk) : base("clinical", chunk)
        {
        }

        public void ChunkData(IEnumerable<Clinical> items = null) =>
            DataTableChunk(items, "patid", "adid");
        // ParallelChunk(item => new[] {item.patid, item.adid}.Select(k => $"{k}").ToArray(), items);

        //  public static void Prepare(Chunk chunk) => GetMe(chunk);

        public Clinical ByPatientAdId(int adid, long patid) => DataTableValue(new {patid, adid});
    }
}