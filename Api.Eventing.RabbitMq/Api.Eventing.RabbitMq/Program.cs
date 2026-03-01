using Nano.App.Api;
using Nano.Eventing.Extensions;
using Nano.Eventing.RabbitMq;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoEventing<RabbitMqProvider>();
    })
    .Build()
    .Run();
