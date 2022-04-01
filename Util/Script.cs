using System;
using System.IO;

namespace Util
{
    public class Script
    {
        public static string ForCPRDGOLD(string fileName) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scripts", "cprdgold", fileName);
        public static string ForCPRDGOLD<C>() => ForCPRDGOLD($"{typeof(C).Name.ToKebabCase()}.sql");
    }
}
