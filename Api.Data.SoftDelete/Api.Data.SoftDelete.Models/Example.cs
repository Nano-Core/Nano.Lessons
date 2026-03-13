using Nano.Data.Abstractions.Models;
using Nano.Data.Abstractions.Models.Abstractions;

namespace Api.Data.SoftDelete.Models;

/// <summary>
/// Example.
/// </summary>
public class Example : BaseEntity, IEntitySoftDeletable
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}