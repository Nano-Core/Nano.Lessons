using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.Identity.Authentication.External.Direct.Models;

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