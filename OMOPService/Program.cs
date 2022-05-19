using OMOPService;
using Util;

var host = Host.CreateDefaultBuilder(args)
               .UseWindowsService(options => { options.ServiceName = Consts.SERVICE_NAME; })
               .ConfigureServices(services =>
               {
                   services.AddSingleton<OMOPServe>();
                   services.AddHostedService<Worker>();
               })
               .Build();

await host.RunAsync();