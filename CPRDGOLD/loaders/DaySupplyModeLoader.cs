using System.Collections.Generic;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    public class DaySupplyModeLoader : FullLoader<DaySupplyModeLoader, DaySupplyMode>
    {
        public DaySupplyModeLoader() : base("daysupply_modes")
        {
        }

        public override void ChunkData(IEnumerable<DaySupplyMode> items = null)
        {
            DataTableChunk(items, "prodcode");
            //ParallelChunk(item => new[] { $"{item.prodcode}" }, items);
        }

        public static DaySupplyMode ByProdcode(int code) => DataTableValue(new {prodcode = code});
    }
}