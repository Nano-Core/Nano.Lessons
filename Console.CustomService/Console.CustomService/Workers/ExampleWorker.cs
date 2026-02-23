using System;
using System.Threading;
using System.Threading.Tasks;
using Console.CustomService.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Nano.App.Console.Workers;

namespace Console.CustomService.Workers;

/// <summary>
/// Example Worker.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
/// <param name="exampleService">The <see cref="IExampleService"/>.</param>
public class ExampleWorker(ILogger logger, IExampleService exampleService) : BaseWorker(logger)
{
    private readonly IExampleService exampleService = exampleService ?? throw new ArgumentNullException(nameof(exampleService));

    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Example Worker Started...");

        var message = await this.exampleService
            .GetMessage();

        System.Console.WriteLine(message);

        System.Console.WriteLine("Example Worker Completed...");
    }
}