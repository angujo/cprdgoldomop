﻿using CPRDGOLD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace CPRDGOLD.loaders
{
    internal class TherapyLoader : ChunkLoader<TherapyLoader, Therapy>
    {
        public TherapyLoader() : base("therapy") { }
        public TherapyLoader(Chunk chunk) : base("therapy", chunk) { }
    }
}
