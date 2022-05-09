using System.Collections.Generic;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    public class CommonDosageLoader : FullLoader<CommonDosageLoader, CommonDosage>
    {
        public CommonDosageLoader() : base("commondosages") { }
        public override void ChunkData(IEnumerable<CommonDosage> items = null)
        {
            ParallelChunk(sstd => new[] { sstd.dosageid }, items);
        }

        public static CommonDosage ByDoseId(string cd_id) => ChunkValue(cd_id);
    }
}
