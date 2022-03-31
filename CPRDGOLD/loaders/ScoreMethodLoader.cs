using CPRDGOLD.models;
using System.Collections.Generic;

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
