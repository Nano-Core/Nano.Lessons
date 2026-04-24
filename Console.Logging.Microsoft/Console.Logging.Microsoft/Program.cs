using Nano.App.Console;
using Nano.Logging.Extensions;
using Nano.Logging.Microsoft;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoLogging<MicrosoftProvider>();
    })
    .Build()
    .Run();