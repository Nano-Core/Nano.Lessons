using Console.Data.SqLite.Data;
using Nano.App.Console;
using Nano.Data.Extensions;
using Nano.Data.SqLite;
using System;
using System.IO;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoData<SqLiteProvider, SqLiteDbContext>();
    })
    .Build()
    .Run();