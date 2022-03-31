using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.loaders
{
    internal class ActivePatientLoader : ChunkLoader<ActivePatientLoader, Patient>
    {
        public ActivePatientLoader() : base("patient") { }
        public ActivePatientLoader(Chunk chunk) : base("patient", chunk) { }
    }
}
