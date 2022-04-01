using System;
using System.Configuration;
using System.IO;

namespace Util
{
    public class Setting
    {
        private static KeyValueConfigurationCollection appSettings { get; set; }

        public static string AppConnection { get { return SettingValue("app_conn"); } }
        public static string TargetConnection { get { return SettingValue("target_conn"); } }
        public static string SourceConnection { get { return SettingValue("source_conn"); } }
        public static string VocabConnection { get { return SettingValue("vocabulary_conn"); } }
        public static string TargetSchema { get { return SettingValue("target_schema"); } }
        public static string SourceSchema { get { return SettingValue("source_schema"); } }
        public static string AppSchema { get { return SettingValue("app_schema"); } }
        public static string VocabSchema { get { return SettingValue("vocabulary_schema"); } }

        private static KeyValueConfigurationCollection AppSetting()
        {
            if (null != appSettings) return appSettings;
            ExeConfigurationFileMap fm = new ExeConfigurationFileMap();
            fm.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.config");
            Log.Info($"Configuration Path: {fm.ExeConfigFilename}");
            Configuration conf = ConfigurationManager.OpenMappedExeConfiguration(fm, ConfigurationUserLevel.None);
            return appSettings = conf.AppSettings.Settings;
        }

        protected static string SettingValue(string key) => AppSetting()[key]?.Value;
    }
}
