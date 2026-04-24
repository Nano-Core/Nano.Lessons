using System.Threading.Tasks;
using Console.CustomService.Services.Abstractions;

namespace Console.CustomService.Services;

/// <summary>
/// Example Service.
/// </summary>
public class ExampleService : IExampleService
{
    /// <inheritdoc />
    public Task<string> GetMessage()
    {
        return Task.FromResult("Message from example service.");
    }
}