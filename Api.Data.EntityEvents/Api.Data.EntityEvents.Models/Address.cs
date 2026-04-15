using Nano.Data.Abstractions.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.Data.EntityEvents.Models;

/// <summary>
/// Address.
/// </summary>
public class Address : BaseEntity
{
    /// <summary>
    /// Street.
    /// </summary>
    [Required]
    public virtual string Street { get; set; } = null!;

    /// <summary>
    /// Profile.
    /// </summary>
    public virtual Profile? Profile { get; set; }
}