using CPRDGOLD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class TestLoader : ChunkLoader<TestLoader, Test>
    {
        public TestLoader() : base("test") { }
        public TestLoader(Chunk chunk) : base("test", chunk) { }
    }
}
