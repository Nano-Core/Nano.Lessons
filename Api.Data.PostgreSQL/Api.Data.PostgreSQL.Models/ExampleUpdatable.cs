using Nano.Data.Abstractions.Models;

namespace Api.Data.PostgreSQL.Models;

/// <summary>
/// Example.
/// </summary>
public class ExampleUpdatable : BaseEntityUpdatable
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}