using Nano.Data.Abstractions.Models;
using Nano.Data.Abstractions.Models.Abstractions;

namespace Api.Data.MySql.Views.Models;

/// <summary>
/// Example View.
/// </summary>
public class ExampleView : BaseEntityReadOnly
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}