using Microsoft.Extensions.Logging;
using Nano.App.Console.Workers;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Console.Localization.Workers;

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

        await Task.CompletedTask;

        System.Console.WriteLine($"Culture: {CultureInfo.CurrentCulture.Name}");
        System.Console.WriteLine($"DateTime: {DateTime.Now}");
        System.Console.WriteLine($"Long date: {DateTime.Now:D}");
        System.Console.WriteLine($"Number: {1234567.89.ToString(CultureInfo.InvariantCulture)}");
        System.Console.WriteLine($"Currency: {1234.56m:C}");
        System.Console.WriteLine($"Percent: {0.256:P}");

        System.Console.WriteLine("Example Worker Completed...");
    }
}