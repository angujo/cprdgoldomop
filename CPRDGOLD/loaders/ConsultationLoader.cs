using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.loaders
{
    internal class ConsultationLoader:ChunkLoader<ConsultationLoader,Consultation>
    {
        public ConsultationLoader() : base("consultation") { }
        public ConsultationLoader(Chunk chunk) : base("consultation", chunk) { }
    }
}
