using CPRDGOLD;
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
                CPRDGOLDMap.Run(u => UP = u);
            }
        }
    }
}
