using Api.Authorization.Extensions;
using Nano.App.Api;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddCustomAuthorizationPolicy();
    })
    .Build()
    .Run();
