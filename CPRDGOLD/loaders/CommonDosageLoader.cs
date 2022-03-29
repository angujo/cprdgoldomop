using CPRDGOLD.models;
using DBMS;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    public class CommonDosageLoader : FullLoader<CommonDosageLoader, CommonDosage>
    {
        public CommonDosageLoader() : base("commondosages") { }
        public override void ChunkData(IEnumerable<CommonDosage> items = null)
        {
            ParallelChunk(sstd => new string[] { sstd.dosageid }, items);
        }

        public static CommonDosage ByDoseId(string cd_id) => ChunkValue(cd_id);
    }
}
