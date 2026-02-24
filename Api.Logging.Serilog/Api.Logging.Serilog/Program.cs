using Nano.App.Api;
using Nano.Logging.Extensions;
using Nano.Logging.Serilog;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoLogging<SerilogProvider>();
    })
    .Build()
    .Run();
