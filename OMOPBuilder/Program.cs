// See https://aka.ms/new-console-template for more information


using CPRDGOLD;
using System.Diagnostics;
using Util;

Log.Info("Starting the app...");
// Log.Error("Something Happened...");

Log.Info($"Launched from {Environment.CurrentDirectory}");
Log.Info($"Physical location {AppDomain.CurrentDomain.BaseDirectory}");
Log.Info($"AppContext.BaseDir {AppContext.BaseDirectory}");
Log.Info($"Runtime Call {Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName)}");

// var sts =Setting.SettingValue("app_conn");
// var sts = Setting.AppSetting();
CPRDGOLDMap.Run((i,v) => { });

