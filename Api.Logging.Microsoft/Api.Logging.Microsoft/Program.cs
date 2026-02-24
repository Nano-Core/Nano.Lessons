using Nano.App.Api;
using Nano.Logging.Extensions;
using Nano.Logging.Microsoft;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoLogging<MicrosoftProvider>();
    })
    .Build()
    .Run();
