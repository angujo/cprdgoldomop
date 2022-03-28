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
    internal class MedicalLoader : FullLoader<MedicalLoader, Medical>
    {
        public MedicalLoader() : base("medical") { }
        public override void ChunkData(IEnumerable<Medical> items = null)
        {
            ParallelChunk(new List<Action<Medical>>
            {
                item =>AddChunkByKeys(item,null,$"{item.medcode}"),       //  Medcode
            },items);
        }

        public static Medical ByMedcode(string medcode)
        {
            if (!long.TryParse(medcode, out long mc)) return new Medical();
            return ByMedcode(mc);
        }

        public static Medical ByMedcode(long medcode)
        {
            // return GetMe().searchOne(m => m.medcode == medcode, $"medcode{medcode}") ?? new Medical();
            return ChunkValue(null, $"{medcode}");
        }
    }
}
