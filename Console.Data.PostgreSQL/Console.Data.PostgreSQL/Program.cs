using Console.Data.PostgreSQL.Data;
using Nano.App.Console;
using Nano.Data.Extensions;
using Nano.Data.PostgreSQL;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoData<PostgreSqlProvider, PostgreSqlDbContext>();
    })
    .Build()
    .Run();