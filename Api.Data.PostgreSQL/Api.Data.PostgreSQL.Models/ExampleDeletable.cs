using Nano.Data.Abstractions.Models;

namespace Api.Data.PostgreSQL.Models;

/// <summary>
/// Example.
/// </summary>
public class ExampleDeletable : BaseEntityDeletable
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}