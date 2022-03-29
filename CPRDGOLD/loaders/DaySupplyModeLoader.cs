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
