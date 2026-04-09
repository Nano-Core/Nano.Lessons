using Nano.Data.Abstractions.Eventing.Annotations;
using Nano.Data.Abstractions.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.Data.EntityEvents.Models;

/// <summary>
/// Example Parent.
/// </summary>
[Publish(nameof(Identitifer))]
public class Person : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    public virtual string Identitifer { get; set; } = null!;
}