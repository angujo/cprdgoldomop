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
        public override void ChunkData()
        {
            ParallelChunk(new List<Action<DaySupplyDecode>>
            {
                item =>AddChunkByKeys(item,new decimal[]{item.prodcode, (decimal)item.qty, (decimal)item.daily_dose, (decimal)item.numpacks }.Select(k=>$"{k}").ToArray()),       // ProdCode
            });
        }
        public static DaySupplyDecode ByAll(int code, int? ddose, int? qty, int? npack)
        {
            // return GetMe().searchOne(cd => cd.prodcode == code && cd.qty == (null != qty && 0 < qty ? qty : 0) && cd.daily_dose == (null == ddose ? 0 : ddose) && cd.numpacks == (null == npack ? 0 : npack), $"allp{code}{ddose}{qty}{npack}".ToSnakeCase());
            return ChunkValue(new int[] { code, ((int)(null != qty && 0 < qty ? qty : 0)), ((int)(null == ddose ? 0 : ddose)), ((int)(null == npack ? 0 : npack)) }.Select(k => $"{k}").ToArray());
        }
    }
}
