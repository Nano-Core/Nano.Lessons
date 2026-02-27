using Nano.App.Api;
using Nano.Storage.Azure;
using Nano.Storage.Extensions;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoStorage<AzureFileshareProvider>();
    })
    .Build()
    .Run();
