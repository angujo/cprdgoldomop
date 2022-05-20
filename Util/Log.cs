using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Concurrent;
using System.IO;
using Serilog;

namespace Util
{
    public static class Log
    {
        private static NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private static readonly ConcurrentDictionary<int, Logger> _instances =
            new ConcurrentDictionary<int, NLog.Logger>();


        public static void Error(string msg) => File.Error(msg);
        public static void Info(string msg, params object[] args) => File.Info(msg, args);
        public static void Warning(string msg, params object[] args) => File.Warning(msg, args);

        /*public static void Info(string msg, int chunkId, params object[] args) =>
            Info($"[CHUNK {chunkId}] {msg}", args);*/

        public static void Error(Exception exc) => File.Error(exc);


        public class Chunk
        {
            protected LogWriter _writer;
            protected long      chunkId;

            public Chunk(long ord)
            {
                chunkId = ord;
            }

            private LogWriter getWriter() => _writer ?? (_writer = LogWriter.ForChunk(chunkId));

            public void Error(string msg, params object[] args) =>
                getWriter().Error("[CHUNK #{chunkid}] " + msg, args.Prepend(chunkId));

            public void Info(string msg, params object[] args) =>
                getWriter().Info("[CHUNK #{chunkid}] " + msg, args.Prepend(chunkId));

            public void Warning(string msg, params object[] args) =>
                getWriter().Warning("[CHUNK #{chunkid}] " + msg, args.Prepend(chunkId));

            public void Error(Exception exception) => getWriter().Error(exception);

            public void SetChunkId(long cid)
            {
                if (cid == chunkId) return;
                chunkId = cid;
                _writer = LogWriter.ForChunk(cid);
            }
        }

        public class File
        {
            protected static LogWriter _writer;

            private static LogWriter getWriter()
            {
                return _writer ?? (_writer = LogWriter.ForFile());
            }

            public static void Error(string msg, params object[] args) => getWriter().Error(msg, args);
            public static void Info(string msg, params object[] args) => getWriter().Info(msg, args);
            public static void Warning(string msg, params object[] args) => getWriter().Warning(msg, args);
            public static void Error(Exception exception) => getWriter().Error(exception);
        }

        public class Console
        {
            protected static LogWriter _writer;

            private static LogWriter getWriter()
            {
                return _writer ?? (_writer = LogWriter.ForConsole());
            }

            public static void Error(string msg, params object[] args) => getWriter().Error(msg, args);
            public static void Info(string msg, params object[] args) => getWriter().Info(msg, args);
            public static void Warning(string msg, params object[] args) => getWriter().Warning(msg, args);
            public static void Error(Exception exception) => getWriter().Error(exception);
        }

        public class LogWriter
        {
            public void Error(string msg, params object[] args)=>_logger.Error(msg, args);

            public void Info(string msg, params object[] args)=>                _logger.Information(msg, args);

            public void Warning(string msg, params object[] args)=> _logger.Warning(msg, args);

            public void Error(Exception exception, string msg = null) =>
                _logger.Error(exception, msg ?? exception.Message);

            private Serilog.Core.Logger _logger;

            private LogWriter()
            {
            }

            public static LogWriter ForConsole()
            {
                var m = new LogWriter
                {
                    _logger = new LoggerConfiguration()
                              .MinimumLevel.Debug()
                              .WriteTo.Console()
                              .CreateLogger()
                };
                return m;
            }

            public static LogWriter ForFile()
            {
                var m = new LogWriter
                {
                    _logger = new LoggerConfiguration()
                              .MinimumLevel.Debug()
                              .WriteTo.File(
                                  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "seriallog.txt"),
                                  rollingInterval: RollingInterval.Day)
                              .CreateLogger()
                };
                return m;
            }

            public static LogWriter ForChunk(long ordinal)
            {
                var m = new LogWriter
                {
                    _logger = new LoggerConfiguration()
                              .MinimumLevel.Debug()
                              .WriteTo.File(
                                  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", $"chunk{ordinal}",
                                               "log.txt"),
                                  rollingInterval: RollingInterval.Day)
                              .CreateLogger()
                };
                return m;
            }
        }
    }
}