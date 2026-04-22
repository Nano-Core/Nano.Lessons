using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Eventing.RabbitMq.Eventing.Models;
using Nano.Eventing.Abstractions;

namespace Api.Eventing.RabbitMq.Eventing;

/// <inheritdoc />
public class EventingHandlerRoutingKey() : BaseEventHandler<EventModel>("routing-key")
{
    /// <inheritdoc />
    public override async Task CallbackAsync(EventModel @event, bool isRedelivered, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        Console.WriteLine($"Event Routed: {@event.Text}");
    }
}