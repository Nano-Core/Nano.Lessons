using Nano.Data.Abstractions.Models;

namespace Api.Data.Audit.Models;

/// <summary>
/// Example.
/// </summary>
public class ExampleNoAudit : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}