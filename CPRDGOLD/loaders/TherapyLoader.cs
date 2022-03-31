using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.loaders
{
    internal class TherapyLoader : ChunkLoader<TherapyLoader, Therapy>
    {
        public TherapyLoader() : base("therapy") { }
        public TherapyLoader(Chunk chunk) : base("therapy", chunk) { }
    }
}
