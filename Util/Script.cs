using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Script
    {
        public static string ForCPRDGOLD(string fileName) => Path.Combine(Environment.CurrentDirectory, "scripts", "cprdgold", fileName);
        public static string ForCPRDGOLD<C>() => ForCPRDGOLD($"{typeof(C).Name.ToKebabCase()}.sql");
    }
}
