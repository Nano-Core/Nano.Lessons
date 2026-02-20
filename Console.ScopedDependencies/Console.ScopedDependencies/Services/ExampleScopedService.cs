using System.Threading.Tasks;
using Console.Workers.Services.Abstractions;

namespace Console.Workers.Services;

/// <inheritdoc />
internal class ExampleScopedService : IExampleScopedService
{
    /// <inheritdoc />
    public async Task Run()
    {
        await Task.CompletedTask;

        System.Console.WriteLine("Example Worker Scoped Service invoked");
    }
}