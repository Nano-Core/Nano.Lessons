using Microsoft.Extensions.Logging;
using Nano.App.Console.Workers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Console.StartupTasks.Workers;

/// <summary>
/// Example Worker.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExampleWorker(ILogger logger) : BaseWorker(logger)
{
    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Example Worker Started...");

        await Task.Delay(100, cancellationToken);

        System.Console.WriteLine(DateTime.UtcNow);

        System.Console.WriteLine("Example Worker Completed...");
    }
}