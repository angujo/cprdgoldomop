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
        public override void ChunkData()
        {
            ParallelChunk(new List<Action<CommonDosage>>
            {
                sstd =>AddChunkByKeys(sstd,new string[]{null,sstd.dosageid}),        // DosageId
            });
        }

        public static CommonDosage ByDoseId(string cd_id)
        {
            //return GetMe().searchOne(cd => cd.dosageid == cd_id, $"dosageid{cd_id}".ToSnakeCase());
            //  return GetMe().QuerySearchOne("dosageid = ?", new object[] { cd_id },cd => cd.dosageid == cd_id);
            return ChunkValue(null, cd_id);
        }
    }
}
