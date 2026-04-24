using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nano.App.Console.Workers;

namespace Console.Logging.Log4Net.Workers;

/// <summary>
/// Example Worker.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class ExampleWorker(ILogger<ExampleWorker> logger) : BaseWorker(logger)
{
    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Example Worker Started...");

        await Task.Delay(500, cancellationToken);

        this.logger
            .LogWarning("warning from worker");

        System.Console.WriteLine("Example Worker Completed...");
    }
}