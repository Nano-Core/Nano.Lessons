using System.Threading.Tasks;

namespace Console.CustomService.Services.Abstractions;

/// <summary>
/// Example Service Interface.
/// </summary>
public interface IExampleService
{
    /// <summary>
    /// Get Message.
    /// </summary>
    /// <returns>A message.</returns>
    Task<string> GetMessage();
}