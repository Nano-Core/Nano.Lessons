using System.Collections.Generic;
using Nano.Data.Abstractions.Models;
using Nano.Data.Abstractions.Models.Abstractions;

namespace Api.Data.Audit.Models;

/// <summary>
/// Example Navigation.
/// </summary>
public class ExampleNavigation : BaseEntity, IEntityAuditable, IEntitySoftDeletable
{
    /// <summary>
    /// Navigation Name.
    /// </summary>
    public virtual string NavigationName { get; set; } = null!;

    /// <summary>
    /// Examples.
    /// </summary>
    public virtual ICollection<Example> Examples { get; set; } = [];
}