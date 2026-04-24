using Nano.Data.Abstractions.Models;

namespace Api.Data.InMemory.Models;

/// <summary>
/// Example.
/// </summary>
public class ExampleCreatable : BaseEntityCreatable
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}