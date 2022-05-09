using System;
using CPRDGOLD.post;

namespace CPRDGOLD
{
    internal class PostMap
    {
        public static void Implement<C>() where C : new() => ((PostRunner)(Object)new C()).Implement();

    }
}
