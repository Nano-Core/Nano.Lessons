using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Eventing.RabbitMq.Eventing.Models;
using Nano.Eventing.Abstractions;

namespace Api.Eventing.RabbitMq.Eventing;

/// <inheritdoc />
public class EventingHandlerRoutingKey : BaseEventHandler<EventModelRoutingKey>
{
    /// <summary>
    /// Routing Key.
    /// </summary>
    public static string RoutingKey => "routing-key";

    /// <inheritdoc />
    public override async Task CallbackAsync(EventModelRoutingKey @event, bool isRedelivered, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        Console.WriteLine($"Event Routed: {@event.Text}");
    }
}