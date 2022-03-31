using System.Configuration;

namespace Util
{
    public class Setting
    {
        public static string AppConnection { get { return ConfigurationManager.AppSettings.Get("app_conn"); } }
        public static string TargetConnection { get { return ConfigurationManager.AppSettings.Get("target_conn"); } }
        public static string SourceConnection { get { return ConfigurationManager.AppSettings.Get("source_conn"); } }
        public static string VocabConnection { get { return ConfigurationManager.AppSettings.Get("vocabulary_conn"); } }
        public static string TargetSchema { get { return ConfigurationManager.AppSettings.Get("target_schema"); } }
        public static string SourceSchema { get { return ConfigurationManager.AppSettings.Get("source_schema"); } }
        public static string AppSchema { get { return ConfigurationManager.AppSettings.Get("app_schema"); } }
        public static string VocabSchema { get { return ConfigurationManager.AppSettings.Get("vocabulary_schema"); } }
    }
}
