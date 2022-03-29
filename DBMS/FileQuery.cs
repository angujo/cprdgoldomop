using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (!File.Exists(_filePath)) return null;
            return File.ReadAllText(_filePath).RemovePlaceholders(PH_Others);
        }

        private dynamic RunQuery()
        {
            string sql = Content();
            if (null == sql) return null;
            return DB.Target.RunQuery(sql);
        }

        public static void ExecuteFile(string filePath, params string[][] placeholders) => new FileQuery(filePath, placeholders).RunQuery();
    }
}
