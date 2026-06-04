using Api.Data.EntityEvents.Subscriber.Data;
using Nano.App.Api;
using Nano.Data.Extensions;
using Nano.Data.MySql;
using Nano.Eventing.Extensions;
using Nano.Eventing.RabbitMq;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoData<MySqlProvider, MySqlDbContext>();
        x.AddNanoEventing<RabbitMqProvider>();
    })
    .Build()
    .Run();
