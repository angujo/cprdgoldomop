using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.loaders
{
    internal class AdditionalLoader : ChunkLoader<AdditionalLoader, Additional>
    {
        public AdditionalLoader() : base("additional") { }
        public AdditionalLoader(Chunk chunk) : base("additional", chunk) { }
    }
}
