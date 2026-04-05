using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.EntityEvents.Models;

/// <summary>
/// Example Navigation.
/// </summary>
public class ExampleNavigation : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    public virtual string NavigationName { get; set; } = null!;

    /// <summary>
    /// Examples.
    /// </summary>
    [Required]
    public virtual ICollection<Example> Examples { get; set; } = [];

    /// <summary>
    /// Examples Included.
    /// </summary>
    [Required]
    public virtual ICollection<Example> ExamplesIncluded { get; set; } = [];
}