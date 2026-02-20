using Console.Workers.Services;
using Console.Workers.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Nano.App.Console;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddScoped<IExampleScopedService, ExampleScopedService>();
    })
    .Build()
    .Run();