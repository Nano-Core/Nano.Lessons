using Api.Data.SqlServer.Spatial.Data;
using Nano.App.Api;
using Nano.Data.Extensions;
using Nano.Data.SqlServer;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoData<SqlServerProvider, SqlServerDbContext>();
    })
    .Build()
    .Run();
