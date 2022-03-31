using CPRDGOLD.models;
using DBMS.models;

namespace CPRDGOLD.loaders
{
    internal class ReferralLoader : ChunkLoader<ReferralLoader, Referral>
    {
        public ReferralLoader() : base("referral") { }
        public ReferralLoader(Chunk chunk) : base("referral", chunk) { }
    }
}
