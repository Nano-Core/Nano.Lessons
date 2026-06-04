using Nano.App.Api;
using Nano.Logging.Extensions;
using Nano.Logging.NLog;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoLogging<NLogProvider>();
    })
    .Build()
    .Run();
