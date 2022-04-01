using System.IO;
using Util;

namespace DBMS
{
    public class FileQuery
    {
        readonly string _filePath;
        readonly string[][] PH_Others;

        protected FileQuery(string filePath, params string[][] other_placeholders)
        {
            _filePath = filePath;
            PH_Others = other_placeholders;
        }

        private string Content()
        {
            if (!File.Exists(_filePath)) throw new FileNotFoundException($"Executable file {_filePath} was not found!");
            Log.Info($"Execution content from file {_filePath}");
            return File.ReadAllText(_filePath).RemovePlaceholders(PH_Others);
        }

        private dynamic RunQuery()
        {
            string sql = Content();
            if (null == sql) return null;
            // Log.Info($"content For Execution: {sql}");
            return DB.Target.RunQuery(sql);
        }

        public static void ExecuteFile(string filePath, params string[][] placeholders) => new FileQuery(filePath, placeholders).RunQuery();
    }
}
