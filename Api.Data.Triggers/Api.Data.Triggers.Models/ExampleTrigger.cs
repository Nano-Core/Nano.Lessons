using System;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.Triggers.Models;

/// <summary>
/// Example Trigger.
/// </summary>
public class ExampleTrigger : BaseEntity
{
    /// <summary>
    /// Example Id.
    /// </summary>
    [Required]
    public virtual Guid ExampleId { get; set; }

    /// <summary>
    /// Trigger.
    /// </summary>
    public virtual string Trigger { get; set; } = null!;
}