using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nano.App.Console.Workers;

namespace Console.Workers.Workers;

/// <summary>
/// Another Example Worker.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class AnotherExampleWorker(ILogger<AnotherExampleWorker> logger) : BaseWorker(logger)
{
    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Another Example Worker Started...");

        await Task.Delay(1000, cancellationToken);

        System.Console.WriteLine("Another Example Worker Completed...");
    }
}