using CPRDGOLD.post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRDGOLD
{
    internal class PostMap
    {
        public static void Implement<C>() where C : new() => ((PostRunner)(Object)new C()).Implement();

    }
}
