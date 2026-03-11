using Console.Data.MySql.Data;
using Nano.App.Console;
using Nano.Data.Extensions;
using Nano.Data.MySql;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoData<MySqlProvider, MySqlDbContext>();
    })
    .Build()
    .Run();