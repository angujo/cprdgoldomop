using CPRDGOLD.models;
using DBMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    public class DaySupplyDecodeLoader : FullLoader<DaySupplyDecodeLoader, DaySupplyDecode>
    {
        public DaySupplyDecodeLoader() : base("daysupply_decodes") { }
        public override void ChunkData(IEnumerable<DaySupplyDecode> items = null)
        {
            ParallelChunk(item => new decimal[] { item.prodcode, (decimal)item.qty, (decimal)item.daily_dose, (decimal)item.numpacks }.Select(k => $"{k}").ToArray(), items);
        }
        public static DaySupplyDecode ByAll(int code, int? ddose, int? qty, int? npack) => ChunkValue(new int[] { code, ((int)(null != qty && 0 < qty ? qty : 0)), ((int)(null == ddose ? 0 : ddose)), ((int)(null == npack ? 0 : npack)) }.Select(k => $"{k}").ToArray());
    }
}
