using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.loaders
{
    internal class PatientLoader : ChunkLoader<PatientLoader, Patient>
    {
        public PatientLoader() : base("patient") { }
        public PatientLoader(Chunk chunk) : base("patient", chunk) { }
    }
}
