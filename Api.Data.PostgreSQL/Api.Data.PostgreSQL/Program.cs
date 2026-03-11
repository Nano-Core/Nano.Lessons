using Api.Data.PostgreSQL.Data;
using Nano.App.Api;
using Nano.Data.Extensions;
using Nano.Data.PostgreSQL;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoData<PostgresSqlProvider, PostgreSqlDbContext>();
    })
    .Build()
    .Run();
