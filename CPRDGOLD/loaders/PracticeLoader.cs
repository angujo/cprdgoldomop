using CPRDGOLD.models;
using System.Collections.Generic;

namespace CPRDGOLD.loaders
{
    internal class PracticeLoader : FullLoader<PracticeLoader, Practice>
    {
        public PracticeLoader() : base("practice") { }
        public override void ChunkData(IEnumerable<Practice> items = null)
        {
            ParallelChunk(items);
        }
    }
}
