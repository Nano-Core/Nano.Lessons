using System;
using System.Threading.Tasks;
using Api.Eventing.RabbitMq.Eventing.Models;
using Nano.Eventing.Abstractions;

namespace Api.Eventing.RabbitMq.Eventing;

/// <summary>
/// Eventing Handler.
/// </summary>
public class EventingHandler : BaseEventHandler<EventModel>
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

        Console.WriteLine(@event.Text);
    }
}