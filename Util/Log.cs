using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace Util
{
    public static class Log
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private static readonly ConcurrentDictionary<int, Logger> _instances = new ConcurrentDictionary<int, NLog.Logger>();

        private static string LogFolder { get { return Path.Combine(Environment.CurrentDirectory, "log", "chunks"); } }

        public static void Error(string msg) => Logger.Error(msg);
        public static void Info(string msg,params object[] args) => Logger.Info(msg,args);
        public static void Warning(string msg) => Logger.Warn(msg);
        public static void Error(Exception exc) => Logger.Error(exc);
        public static void Info(int index, string msg) => GetInstance(index).Info(msg);
        public static void Error(int index, string msg) => GetInstance(index).Error(msg);
        public static void Error(int index, Exception exc) => GetInstance(index).Error(exc);

        private static NLog.Logger GetInstance(int id) => _instances.ContainsKey(id) ? _instances[id] : (_instances[id] = CreateLogger(id));

        private static Logger CreateLogger(int id)
        {
            string Name = $"Chunker{id}";
            var target = new FileTarget
            {
                Name = Name,
                FileName = Path.Combine(LogFolder, $"{id}.log"),
                ArchiveEvery = FileArchivePeriod.Day,
                ArchiveAboveSize = 10240,
                Layout = "${longdate} ${level:uppercase=true} ${message:withexception=true}"
            };
            var loggingRule = new LoggingRule("*", LogLevel.Debug, target);

            LogManager.Configuration.AddTarget(target);
            LogManager.Configuration.LoggingRules.Add(loggingRule);
            LogManager.Configuration.Reload();

            return LogManager.GetLogger(Name);
        }
    }
}
