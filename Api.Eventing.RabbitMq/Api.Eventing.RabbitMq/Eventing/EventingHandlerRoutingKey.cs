using System;
using System.Threading.Tasks;
using Api.Eventing.RabbitMq.Eventing.Models;
using Nano.Eventing.Abstractions;

namespace Api.Eventing.RabbitMq.Eventing;

/// <summary>
/// Eventing Handler Routing Key.
/// </summary>
public class EventingHandlerRoutingKey() : BaseEventHandler<EventModel>("routing-key")
{
    /// <summary>
    /// Callback.
    /// </summary>
    /// <param name="event">The <see cref="EventModel"/>.</param>
    /// <param name="isRetrying">Whether the event is retrying.</param>
    /// <returns>Nothing.</returns>
    public override async Task CallbackAsync(EventModel @event, bool isRetrying)
    {
        await Task.CompletedTask;

        Console.WriteLine($"Event Routed: {@event.Text}");
    }
}