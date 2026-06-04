using Nano.App.Api;
using Nano.Logging.Extensions;
using Nano.Logging.Log4Net;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoLogging<Log4NetProvider>();
    })
    .Build()
    .Run();
