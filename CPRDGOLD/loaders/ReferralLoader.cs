using CPRDGOLD.models;
using DBMS.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD.loaders
{
    internal class ReferralLoader : ChunkLoader<ReferralLoader, Referral>
    {
        public ReferralLoader() : base("referral") { }
        public ReferralLoader(Chunk chunk) : base("referral", chunk) { }
    }
}
