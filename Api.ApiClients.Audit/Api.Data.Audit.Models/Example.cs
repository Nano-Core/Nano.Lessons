using System;
using Nano.Data.Abstractions.Annotations;
using Nano.Data.Abstractions.Models;
using Nano.Data.Abstractions.Models.Abstractions;

namespace Api.Data.Audit.Models;

/// <summary>
/// Example.
/// </summary>
public class Example : BaseEntity, IEntityAuditable, IEntitySoftDeletable
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Navigation Id.
    /// </summary>
    public virtual Guid? NavigationId { get; set; }

    /// <summary>
    /// Navigation.
    /// </summary>
    [Include]
    public virtual ExampleNavigation? Navigation { get; set; }
}