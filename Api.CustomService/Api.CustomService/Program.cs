using Api.CustomService.Services;
using Api.CustomService.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Nano.App.Api;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddScoped<IExampleService, ExampleService>();
    })
    .Build()
    .Run();
