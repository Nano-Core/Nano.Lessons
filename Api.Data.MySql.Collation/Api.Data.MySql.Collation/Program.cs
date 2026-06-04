using Api.Data.MySql.Collation.Data;
using Nano.App.Api;
using Nano.Data.Extensions;
using Nano.Data.MySql;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoData<MySqlProvider, MySqlDbContext>();
    })
    .Build()
    .Run();
