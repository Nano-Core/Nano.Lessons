using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nano.App.StartUp;

namespace Console.StartupTasks.Startup;

/// <summary>
/// Example Startup Task.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExampleStartupTask(ILogger<ExampleStartupTask> logger) : BaseStartupTask(logger)
{
    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Example Startup Task Started...");

        await Task.Delay(2000, cancellationToken);

        System.Console.WriteLine(DateTime.UtcNow);

        System.Console.WriteLine("Example Startup Task Completed...");
    }
}