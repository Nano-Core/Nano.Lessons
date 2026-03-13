using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;
using Api.Data.MySql.Mappings.Models.Types;

namespace Api.Data.MySql.Mappings.Models;

/// <summary>
/// Example Owned.
/// </summary>
public class ExampleOwned : BaseEntity
{
    /// <summary>
    /// Profile.
    /// </summary>
    [Required]
    public virtual Profile Profile { get; set; } = null!;
}