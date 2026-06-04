using Console.Data.InMemory.Data;
using Nano.App.Console;
using Nano.Data.Extensions;
using Nano.Data.InMemory;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoData<InMemoryProvider, InMemoryDbContext>();
    })
    .Build()
    .Run();