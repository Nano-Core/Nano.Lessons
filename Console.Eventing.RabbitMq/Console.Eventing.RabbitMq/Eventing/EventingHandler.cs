using System.Threading;
using System.Threading.Tasks;
using Console.Eventing.RabbitMq.Eventing.Models;
using Nano.Eventing.Abstractions;

namespace Console.Eventing.RabbitMq.Eventing;

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
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Nothing.</returns>
    public override async Task CallbackAsync(EventModel @event, bool isRetrying, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        System.Console.WriteLine(@event.Text);
    }
}