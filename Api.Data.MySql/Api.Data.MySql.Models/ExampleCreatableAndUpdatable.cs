using Nano.Data.Abstractions.Models;

namespace Api.Data.MySql.Models;

/// <summary>
/// Example.
/// </summary>
public class ExampleCreatableAndUpdatable : BaseEntityCreatableAndUpdatable
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}