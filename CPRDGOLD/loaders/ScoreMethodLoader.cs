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
        public override void ChunkData(IEnumerable<ScoreMethod> items = null)
        {
            ParallelChunk(item => new string[] { $"{item.code}" }, items);
        }

        public static ScoreMethod ByCode(string code) => long.TryParse(code, out long mc) ? ByCode(mc) : null;

        public static ScoreMethod ByCode(long code) => ChunkValue($"{code}");
    }
}
