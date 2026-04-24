using Nano.App.Api;
using Nano.Storage.Extensions;
using Nano.Storage.Local;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoStorage<LocalFileShareProvider>();
    })
    .Build()
    .Run();
