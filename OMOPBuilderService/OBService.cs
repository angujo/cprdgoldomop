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
        private          long  _workload_id;

        public OBService()
        {
            long tick = Convert.ToInt64(Math.Ceiling((double) Consts.SERVICE_TIMER / Consts.SERVICE_CHECKS)),
                r     = 0;
            _timer         = new Timer(tick) {AutoReset = true};
            _timer.Enabled = true;
            _timer.Elapsed += (s, evt) =>
            {
                Intervene();
                if (0 == r) Action();
                r++;
                r = 0 == r % Consts.SERVICE_CHECKS ? 0 : r;
            };
        }

        private void Intervene()
        {
            if (default == _workload_id) return;
            WorkLoad wl;
            if ((wl = DB.Internal.Load<WorkLoad>(_workload_id))?.Id == default ||
                (wl.intervene && Status.RUNNING != wl.Status)) return;
            wl.intervene = true;
            wl.Status    = Status.STOPPED;
            wl.Save();

            Runner.TokenSource.Cancel();
        }

        private void Action()
        {
            Log.Warning("Service Checkup Round...");
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

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
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