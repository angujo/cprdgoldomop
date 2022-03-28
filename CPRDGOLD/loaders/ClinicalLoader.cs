using CPRDGOLD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class ClinicalLoader : ChunkLoader<ClinicalLoader, Clinical>
    {
        public ClinicalLoader() : base("clinical") { }
        public ClinicalLoader(Chunk chunk) : base("clinical", chunk) { }

        public void ChunkData(IEnumerable<Clinical> items = null)
        {
            ParallelChunk(new List<Action<Clinical>>
            {
                item =>AddChunkByKeys(item,new long[]{item.patid,item.adid}),        // Chunk By AdId & PatId
            }, items);
        }

        public static void Prepare(Chunk chunk) => GetMe(chunk);

        public static Clinical ByPatientAdId(Chunk chunk, int adid, long patid)
        {
            //return GetMe(chunk).searchOne(c => c.adid == adid && c.patid == patid, "patidadid" + $"{adid}{patid}".ToSnakeCase());
            return ChunkValue(chunk, patid.ToString(), adid.ToString());
        }
    }
}
