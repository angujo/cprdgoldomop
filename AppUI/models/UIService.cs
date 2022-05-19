using System;
using System.Collections;
using System.Configuration.Install;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using Util;

namespace AppUI.models
{
    public class UIService
    {
        private ServiceController sc;

        public UIService()
        {
            sc = new ServiceController(Consts.SERVICE_NAME);
        }

        public T Status<T>()
        {
            try
            {
                if (typeof(T) == typeof(int)) return (T) (object) sc.Status;
                if (typeof(T) != typeof(string)) return (T) (object) typeof(T).Name;
                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        return (T) (object) "Running";
                    case ServiceControllerStatus.Stopped:
                        return (T) (object) "Stopped";
                    case ServiceControllerStatus.Paused:
                        return (T) (object) "Paused";
                    case ServiceControllerStatus.StopPending:
                        return (T) (object) "Stopping";
                    case ServiceControllerStatus.StartPending:
                        return (T) (object) "Starting";
                    case ServiceControllerStatus.ContinuePending:
                    case ServiceControllerStatus.PausePending:
                    default:
                        return (T) (object) "Status Changing";
                }
            }
            catch (Exception exception)
            {
                var ds = default == sc;
                var ns = new ServiceController("OMOP-Map Service");
                if (typeof(T) == typeof(int)) return (T) (object) 0;
                return (T) (object) "Not Installed!";
            }
        }

        public void Install()
        {
            if (0 != Status<int>()) return;
            IDictionary mySavedState = new Hashtable();
            Log.Info("Starting Service installer!");
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "OMOPService.exe");
                Log.Info(path);
                // Set the commandline argument array for 'logfile'.
                var commandLineOptions = new[] {path};

                // Create an object of the 'AssemblyInstaller' class.
                var myAssemblyInstaller = new AssemblyInstaller("installutil", commandLineOptions);

                myAssemblyInstaller.UseNewContext = true;

                // Install the 'MyAssembly' assembly.
                myAssemblyInstaller.Install(mySavedState);

                // Commit the 'MyAssembly' assembly.
                myAssemblyInstaller.Commit(mySavedState);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Log.Error(e);
                throw;
            }
        }
    }
}