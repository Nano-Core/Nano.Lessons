using System.Collections.Generic;
using Nano.Data.Abstractions.Annotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.LazyLoading.Models;

/// <summary>
/// Example.
/// </summary>
public class Example : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Relations.
    /// </summary>
    public virtual ICollection<ExampleRelation> Relations { get; set; } = [];

    /// <summary>
    /// Relations.
    /// </summary>
    [Include]
    public virtual ICollection<ExampleRelationIncluded> IncludedRelations { get; set; } = [];
}