using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.Identity.Models;

/// <summary>
/// User.
/// </summary>
public class User : BaseEntityUser
{
    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    [MaxLength(128)]
    public virtual string Name { get; set; } = null!;
}