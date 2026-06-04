using Api.CustomService.Services.Abstractions;
using System.Threading.Tasks;

namespace Api.CustomService.Services;

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