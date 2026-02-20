using System;
using System.Threading;
using System.Threading.Tasks;
using Console.Workers.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Nano.App.Console.Workers;

namespace Console.Workers.Workers;

/// <summary>
/// Example Worker.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
/// <param name="scopedService">The <see cref="IExampleScopedService"/>.</param>
public class ExampleWorker(ILogger logger, IExampleScopedService scopedService) : BaseWorker(logger)
{
    private readonly IExampleScopedService scopedService = scopedService ?? throw new ArgumentNullException(nameof(scopedService));

    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Example Worker Started...");

        await this.scopedService
            .Run();

        System.Console.WriteLine("Example Worker Completed...");
    }
}