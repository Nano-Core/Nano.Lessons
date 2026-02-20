using System.Threading.Tasks;

namespace Console.Workers.Services.Abstractions;

/// <summary>
/// Example Scoped Service Interface.
/// </summary>
public interface IExampleScopedService
{
    /// <summary>
    /// Run.
    /// </summary>
    Task Run();
}