using System.Collections.Generic;
using System.Linq;
using CPRDGOLD.models;

namespace CPRDGOLD.loaders
{
    public class DaySupplyDecodeLoader : FullLoader<DaySupplyDecodeLoader, DaySupplyDecode>
    {
        public DaySupplyDecodeLoader() : base("daysupply_decodes")
        {
        }

        public override void ChunkData(IEnumerable<DaySupplyDecode> items = null)
        {
            DataTableChunk(items, "prodcode", "qty", "daily_dose", "numpacks");
            //ParallelChunk(item => new[] { item.prodcode, (decimal)item., (decimal)item., (decimal)item. }.Select(k => $"{k}").ToArray(), items);
        }

        public static DaySupplyDecode ByAll(int code, int? ddose, int? qty, int? npack) =>
            DataTableValue(new
            {
                prodcode = code, daily_dose = ddose ?? 0, qty = null == qty || qty < 0 ? 0 : qty, numpacks = npack ?? 0
            });
        // ChunkValue(new[] { code, ((int)(null != qty && 0 < qty ? qty : 0)), ((int)(null == ddose ? 0 : ddose)), ((int)(null == npack ? 0 : npack)) }.Select(k => $"{k}").ToArray());
    }
}