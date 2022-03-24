using CPRDGOLD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class ReferralLoader : ChunkLoader<ReferralLoader, Referral>
    {
        public ReferralLoader() : base("referral") { }
        public ReferralLoader(Chunk chunk) : base("referral", chunk) { }
    }
}
