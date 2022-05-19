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
                if (typeof(T) == typeof(int)) return (T) (object) 0;
                return (T) (object) "Not Installed!";
            }
        }
    }
}