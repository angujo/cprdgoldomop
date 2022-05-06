using System.IO;
using DBMS;
using Util;

namespace CPRDGOLD.post
{
    public class PostIndex
    {
        public static void Implement<T>() => Implement(typeof(T).Name);

        public static void Implement(string name) =>
            FileQuery.ExecuteFile(Script.ForCPRDGOLD(Path.Combine("indices", $"idx-{name.ToKebabCase()}.sql")));
    }
}