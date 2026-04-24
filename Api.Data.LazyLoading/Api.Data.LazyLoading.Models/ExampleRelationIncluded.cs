using System;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.LazyLoading.Models;

/// <summary>
/// Example Relation Included.
/// </summary>
public class ExampleRelationIncluded : BaseEntity
{
    /// <summary>
    /// Example.
    /// </summary>
    [Required]
    public virtual Guid ExampleId { get; set; }

    /// <summary>
    /// Example.
    /// </summary>
    public virtual Example? Example { get; set; } = null!;

    /// <summary>
    /// Text.
    /// </summary>
    public virtual string? Text { get; set; }
}