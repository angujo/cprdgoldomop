using CPRDGOLD;
using System.Diagnostics;
using Util;

namespace OMOPService
{
    public class OMOPServe
    {
        private bool UP = false;
        public void TryRun()
        {
            if (!UP)
            {
                Log.Info("Initiating workload checkup...");
                // Log.Info($"Launched from {Environment.CurrentDirectory}");
                // Log.Info($"Physical location {AppDomain.CurrentDomain.BaseDirectory}");
                // Log.Info($"AppContext.BaseDir {AppContext.BaseDirectory}");
                // Log.Info($"Runtime Call {Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)}");

                CPRDGOLDMap.Run(u => UP = u);
            }
        }
    }
}
