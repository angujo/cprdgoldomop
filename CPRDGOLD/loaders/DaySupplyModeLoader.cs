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
        public override void ChunkData()
        {
            ParallelChunk(new List<Action<DaySupplyMode>>
            {
                item =>AddChunkByKeys(item,new string[]{null,$"{item.prodcode}"}),       // ProdCode
            });
        }
        public static DaySupplyMode ByProdcode(int code)
        {
            //return GetMe().searchOne(cd => cd.prodcode == code, $"prodcode{code}".ToSnakeCase());
            return ChunkValue(null, $"{code}");
        }
    }
}
