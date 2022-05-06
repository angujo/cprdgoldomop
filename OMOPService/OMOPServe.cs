using CPRDGOLD;
using System.Diagnostics;
using Util;

namespace OMOPService
{
    public class OMOPServe
    {
        private bool _up;

        public void TryRun()
        {
            Log.Warning("Service Checkup Round...");
            // Do Cleanup in the system.
            GC.Collect();
            if (!_up)
            {
                Log.Info("Initiating workload checkup...");
                // Log.Info($"Launched from {Environment.CurrentDirectory}");
                // Log.Info($"Physical location {AppDomain.CurrentDomain.BaseDirectory}");
                // Log.Info($"AppContext.BaseDir {AppContext.BaseDirectory}");
                // Log.Info($"Runtime Call {Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)}");

                CPRDGOLDMap.Run(u => _up = u);
            }
        }
    }
}