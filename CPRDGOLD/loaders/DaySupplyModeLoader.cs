using CPRDGOLD.models;
using System.Collections.Generic;

namespace CPRDGOLD.loaders
{
    public class DaySupplyModeLoader : FullLoader<DaySupplyModeLoader, DaySupplyMode>
    {
        public DaySupplyModeLoader() : base("daysupply_modes") { }
        public override void ChunkData(IEnumerable<DaySupplyMode> items = null)
        {
            ParallelChunk(item => new string[] { $"{item.prodcode}" }, items);
        }
        public static DaySupplyMode ByProdcode(int code) => ChunkValue($"{code}");
    }
}
