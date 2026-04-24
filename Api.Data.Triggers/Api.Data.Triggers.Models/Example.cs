using System;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.Triggers.Models;

/// <summary>
/// Example.
/// </summary>
public class Example : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Updated At.
    /// </summary>
    public virtual DateTimeOffset? UpdatedAt { get; set; }
}