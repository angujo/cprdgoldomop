using System;
using System.IO;

namespace Util
{
    public class Script
    {
        public static string ForCPRDGOLD(string fileName) => Path.Combine(Environment.CurrentDirectory, "scripts", "cprdgold", fileName);
        public static string ForCPRDGOLD<C>() => ForCPRDGOLD($"{typeof(C).Name.ToKebabCase()}.sql");
    }
}
