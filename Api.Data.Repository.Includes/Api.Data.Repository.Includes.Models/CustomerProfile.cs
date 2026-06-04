using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.Repository.Includes.Models;

/// <summary>
/// Customer Profile.
/// </summary>
public class CustomerProfile : BaseEntity
{
    /// <summary>
    /// Customer.
    /// </summary>
    public virtual Customer Customer { get; set; } = null!;

    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    public virtual string Name { get; set; } = null!;
}