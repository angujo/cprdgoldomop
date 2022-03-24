using System;

namespace Util
{
    public static class Log
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Error(string msg) => Logger.Error(msg);
        public static void Info(string msg) => Logger.Info(msg);
        public static void Warning(string msg) => Logger.Warn(msg);
        public static void Error(Exception exc) => Logger.Error(exc);
    }
}
