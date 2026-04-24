using Nano.App.Console;
using Nano.Logging.Extensions;
using Nano.Logging.Log4Net;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoLogging<Log4NetProvider>();
    })
    .Build()
    .Run();