using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Eventing.Annotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.EntityEvents.Models;

/// <summary>
/// Example Parent.
/// </summary>
[Publish(nameof(ParentName))]
public class ExampleParent : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    public virtual string ParentName { get; set; } = null!;
}