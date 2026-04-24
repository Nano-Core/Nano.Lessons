using Nano.App.Console;
using Nano.Logging.Extensions;
using Nano.Logging.NLog;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoLogging<NLogProvider>();
    })
    .Build()
    .Run();