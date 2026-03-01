using Microsoft.Extensions.Logging;
using Nano.App.Console.Workers;
using Nano.Eventing.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Console.Eventing.RabbitMq.Eventing.Models;

namespace Console.Eventing.RabbitMq.Workers;

/// <summary>
/// Example Worker.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="eventing">The <see cref="IEventing"/>.</param>
public class ExampleWorker(ILogger<ExampleWorker> logger, IEventing eventing) : BaseWorker(logger)
{
    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Example Worker Started...");

        await eventing
            .PublishAsync(new EventModel
            {
                Text = "Testing eventing"
            }, cancellationToken: cancellationToken);

        await Task.Delay(500, cancellationToken);

        System.Console.WriteLine("Example Worker Completed...");
    }
}