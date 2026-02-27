using Nano.App.Console;
using Nano.Storage.Azure;
using Nano.Storage.Extensions;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoStorage<AzureFileshareProvider>();
    })
    .Build()
    .Run();