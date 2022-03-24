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

        public static Clinical ByPatientAdId(Chunk chunk, int adid, long patid)
        {
            //return GetMe(chunk).searchOne(c => c.adid == adid && c.patid == patid, "patidadid" + $"{adid}{patid}".ToSnakeCase());
            return GetMe(chunk).QuerySearchOne("adid = ? AND patid = ?", new object[] { adid, patid }, c => c.adid == adid && c.patid == patid);
        }
    }
}
