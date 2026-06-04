using Nano.Data.Abstractions.Models;

namespace Console.Data.SqlServer.Data.Models;

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