using Console.Data.SqlServer.Data;
using Nano.App.Console;
using Nano.Data.Extensions;
using Nano.Data.SqlServer;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoData<SqlServerProvider, SqlServerDbContext>();
    })
    .Build()
    .Run();