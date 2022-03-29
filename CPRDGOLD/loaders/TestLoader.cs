using CPRDGOLD.models;
using DBMS.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.loaders
{
    internal class TestLoader : ChunkLoader<TestLoader, Test>
    {
        public TestLoader() : base("test") { }
        public TestLoader(Chunk chunk) : base("test", chunk) { }
    }
}
