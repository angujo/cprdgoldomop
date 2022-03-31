using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.loaders
{
    internal class ImmunisationLoader:ChunkLoader<ImmunisationLoader,Immunisation>
    {
        public ImmunisationLoader() : base("immunisation") { }
        public ImmunisationLoader(Chunk chunk) : base("immunisation", chunk) { }
    }
}
