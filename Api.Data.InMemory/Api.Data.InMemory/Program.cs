using Api.Data.InMemory.Data;
using Nano.App.Api;
using Nano.Data.Extensions;
using Nano.Data.InMemory;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoData<InMemoryProvider, InMemoryDbContext>();
    })
    .Build()
    .Run();
