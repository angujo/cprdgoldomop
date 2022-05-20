using System;
using System.Timers;
using CPRDGOLD;
using DBMS;
using DBMS.models;
using Util;

namespace OMOPBuilderService
{
    public class OBService
    {
        private          bool  _up;
        private readonly Timer _timer;
        private          long  _workload_id = 0;
        private          bool  cancelled;

        public OBService()
        {
            long tick = Convert.ToInt64(Math.Ceiling((double) Consts.SERVICE_TIMER / Consts.SERVICE_CHECKS)),
                r     = 0;
            Log.Info("Action Time: {act}, Ticker Time {t}",
                     TimeSpan.FromMilliseconds(Consts.SERVICE_TIMER).ToString(),
                     TimeSpan.FromMilliseconds(tick).ToString());
            _timer         = new Timer(tick) {AutoReset = true};
            _timer.Enabled = true;
            _timer.Elapsed += (s, evt) =>
            {
                if (0 == _workload_id)
                {
                    if (cancelled) cancelled = false;
                    Action();
                    return;
                }

                Intervene();
                if (0 == r) Action();
                r++;
                r = 0 == r % Consts.SERVICE_CHECKS ? 0 : r;
            };
        }

        private void Intervene()
        {
            if (cancelled)
            {
                Log.Info("Cancellation of workload ID #{wl} in progress...", +_workload_id);
                cancelled = 0 != _workload_id;
                return;
            }

            if (0 == _workload_id) return;
            Log.Info("Checking Intervention on Workload ID #{wl}", _workload_id);
            WorkLoad wl;
            if ((wl = DB.Internal.Load<WorkLoad>(new {id = _workload_id})) == default || !wl.intervene) return;
            wl.intervene = false;
            wl.Status    = Status.STOPPED;
            wl.Save();
            cancelled = true;
            Runner.TokenSource.Cancel();
        }

        private void Action()
        {
            // Do Cleanup in the system.
            GC.Collect();
            if (_up) return;
            Log.Info("Initiating workload checkup...");
            // Log.Info($"Launched from {Environment.CurrentDirectory}");
            // Log.Info($"Physical location {AppDomain.CurrentDomain.BaseDirectory}");
            // Log.Info($"AppContext.BaseDir {AppContext.BaseDirectory}");
            // Log.Info($"Runtime Call {Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)}");

            CPRDGOLDMap.Run((wl, u) =>
            {
                _up          = u;
                _workload_id = wl;
            });
        }

        private static void CleanRuns()
        {
            DB.Internal.Update<WorkLoad>(new {isrunning = false}, new {isrunning = true});
        }

        public void Start()
        {
            CleanRuns();
            _timer.Start();
        }

        public void Stop()
        {
            Log.Warning("Service Is Stopping...");
            _timer.Stop();
            Runner.TokenSource.Cancel();
        }

        public void Pause()
        {
            Stop();
        }

        public void Continue()
        {
            Start();
        }

        public void Shutdown()
        {
            Stop();
        }
    }
}