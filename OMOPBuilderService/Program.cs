using System;
using Topshelf;
using Util;

namespace OMOPBuilderService
{
    internal class Program
    {
        public static void Main()
        {
            var hf = HostFactory.Run(x =>
            {
                x.Service<OBService>(hc =>
                {
                    hc.ConstructUsing(name => new OBService());
                    hc.WhenStarted(ob => ob.Start());
                    hc.WhenContinued(ob => ob.Continue());
                    hc.WhenShutdown(ob => ob.Shutdown());
                    hc.WhenPaused(ob => ob.Pause());
                    hc.WhenStopped(ob => ob.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription(Consts.SERVICE_DESC);
                x.SetDisplayName(Consts.SERVICE_NAME);
                x.SetServiceName(Consts.SERVICE_NAME);
               // x.SetInstanceName(Consts.SERVICE_NAME);
            });
            Environment.ExitCode = (int) Convert.ChangeType(hf, hf.GetTypeCode());
        }
    }
}