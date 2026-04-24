using System;
using Nano.Data.Abstractions.Models;

namespace Api.Data.MySql.Views.Models;

/// <summary>
/// Example View.
/// </summary>
public class ExampleView : BaseEntityView
{
    /// <summary>
    /// Id.
    /// </summary>
    public virtual Guid Id { get; set; }

    /// <summary>
    /// Created At.
    /// </summary>
    public virtual DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Name Length.
    /// </summary>
    public virtual int NameLength { get; set; }
}