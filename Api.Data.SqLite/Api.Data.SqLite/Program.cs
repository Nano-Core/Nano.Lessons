using Api.Data.SqLite.Data;
using Nano.App.Api;
using Nano.Data.Extensions;
using Nano.Data.SqLite;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoData<SqLiteProvider, SqLiteDbContext>();
    })
    .Build()
    .Run();
