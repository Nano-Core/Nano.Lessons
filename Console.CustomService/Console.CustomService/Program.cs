using Console.CustomService.Services;
using Console.CustomService.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Nano.App.Console;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddScoped<IExampleService, ExampleService>();
    })
    .Build()
    .Run();