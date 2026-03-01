using Nano.App.Console;
using Nano.Eventing.Extensions;
using Nano.Eventing.RabbitMq;

NanoConsoleApplication
    .ConfigureApp(args)
    .ConfigureServices(x =>
    {
        x.AddNanoEventing<RabbitMqProvider>();
    })
    .Build()
    .Run();