using System;
using System.Threading;
using System.Threading.Tasks;
using Console.CustomConfigSection.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nano.App.Console.Workers;

namespace Console.CustomConfigSection.Workers;

/// <summary>
/// Example Worker.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="customOptions">The <see cref="CustomOptions"/>.</param>
public class ExampleWorker(ILogger<ExampleWorker> logger, IOptionsMonitor<CustomOptions> customOptions) : BaseWorker(logger)
{
    private readonly IOptionsMonitor<CustomOptions> customOptions = customOptions ?? throw new ArgumentNullException(nameof(customOptions));

    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Example Worker Started...");

        await Task.CompletedTask;

        System.Console.WriteLine($"Custom Config Section Value: '{this.customOptions.CurrentValue.Value}'");

        System.Console.WriteLine("Example Worker Completed...");
    }
}