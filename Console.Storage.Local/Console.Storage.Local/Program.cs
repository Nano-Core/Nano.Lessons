using Nano.App.Console;
using Nano.Storage.Extensions;
using Nano.Storage.Local;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoStorage<LocalFileShareProvider>();
    })
    .Build()
    .Run();