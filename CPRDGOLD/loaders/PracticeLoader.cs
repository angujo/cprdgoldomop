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
    internal class PracticeLoader : FullLoader<PracticeLoader, Practice>
    {
        public PracticeLoader() : base("practice") { }
        public override void ChunkData(IEnumerable<Practice> items = null)
        {
            ParallelChunk(items);
        }
    }
}
