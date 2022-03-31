using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.loaders
{
    internal class TestLoader : ChunkLoader<TestLoader, Test>
    {
        public TestLoader() : base("test") { }
        public TestLoader(Chunk chunk) : base("test", chunk) { }
    }
}
