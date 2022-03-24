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
    internal class ScoreMethodLoader : FullLoader<ScoreMethodLoader, ScoreMethod>
    {
        public ScoreMethodLoader() : base("scoremethod") { }
        public override void ChunkData()
        {
            ParallelChunk(new List<Action<ScoreMethod>>
            {
                item =>AddChunkByKeys(item,null,$"{item.code}"),       //  Medcode
            });
        }

        public static ScoreMethod ByCode(string code)
        {
            if (!long.TryParse(code, out long mc)) return new ScoreMethod();
            return ByCode(mc);
        }

        public static ScoreMethod ByCode(long code)
        {
            //  return GetMe().searchOne(m => m.code == code, $"code{code}") ?? new ScoreMethod();
            return ChunkValue(null,$"{code}");
        }
    }
}
