using Nano.Data.Abstractions.Models;

namespace Api.Data.Repository.Includes.Models;

/// <summary>
/// Example.
/// </summary>
public class Example : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}