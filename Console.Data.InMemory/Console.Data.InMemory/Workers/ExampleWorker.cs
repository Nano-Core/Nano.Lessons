using System;
using System.Threading;
using System.Threading.Tasks;
using Console.Data.InMemory.Data.Models;
using Microsoft.Extensions.Logging;
using Nano.App.Console.Workers;
using Nano.Data.Abstractions;

namespace Console.Data.InMemory.Workers;

/// <summary>
/// Example Worker.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExampleWorker(ILogger<ExampleWorker> logger, IRepository repository) : BaseWorker(logger)
{
    private readonly IRepository repository = repository ?? throw new ArgumentNullException(nameof(repository));

    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Example Worker Started...");

        var example = await this.repository
            .AddAsync(new Example
            {
                Name = "name"
            }, cancellationToken);

        await this.repository
            .SaveChangesAsync(cancellationToken);

        example = await this.repository
            .GetAsync<Example>(example.Id, cancellationToken);

        System.Console.WriteLine($"The example name is: '{example!.Name}'");

        System.Console.WriteLine("Example Worker Completed...");
    }
}