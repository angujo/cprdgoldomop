using OMOPService;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "OMOP-Map Service";
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<OMOPServe>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
