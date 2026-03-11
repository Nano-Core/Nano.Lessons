using Nano.Data.Abstractions.Models;

namespace Api.Data.MySql.Views.Models;

/// <summary>
/// Example.
/// </summary>
public class Example : BaseEntityReadOnly
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}