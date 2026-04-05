using System;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Annotations;
using Nano.Data.Abstractions.Eventing.Annotations;

namespace Api.Data.EntityEvents.Models;

/// <summary>
/// Example.
/// </summary>
[Publish(
    nameof(Name), 
    nameof(NavigationId), 
    $"{nameof(Navigation)}.{nameof(ExampleNavigation.NavigationName)}", 
    $"{nameof(NavigationIncluded)}.{nameof(ExampleNavigation.NavigationName)}")]
public class Example : ExampleParent
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Navigation Id.
    /// </summary>
    [Required]
    public virtual Guid NavigationId { get; set; } = Guid.Empty;

    /// <summary>
    /// Navigation.
    /// </summary>
    public virtual ExampleNavigation? Navigation { get; set; }

    /// <summary>
    /// Navigation Included Id.
    /// </summary>
    [Required]
    public virtual Guid NavigationIncludedId { get; set; } = Guid.Empty;

    /// <summary>
    /// Navigation Included.
    /// </summary>
    [Include]
    public virtual ExampleNavigation? NavigationIncluded { get; set; }
}