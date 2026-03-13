using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.MySql.Mappings.Models;

/// <summary>
/// Example Normalized.
/// </summary>
public class ExampleNormalized : BaseEntity
{
    private string firstName = null!;
    private string lastName = null!;

    /// <summary>
    /// First Name.
    /// </summary>
    [Required]
    [MaxLength(128)]
    public virtual string FirstName
    {
        get => this.firstName;
        set
        {
            this.firstName = value;
            this.FullName = $"{this.firstName} {this.lastName}";
        }
    }

    /// <summary>
    /// Last Name.
    /// </summary>
    [Required]
    [MaxLength(128)]
    public virtual string LastName
    {
        get => this.lastName;
        set
        {
            this.lastName = value;
            this.FullName = $"{this.firstName} {this.lastName}";
        }
    }

    /// <summary>
    /// Full Name.
    /// </summary>
    [Required]
    [MaxLength(256)]
    public virtual string FullName
    {
        get;
        set
        {
            field = value;
            this.FullNameNormalized = value.ToUpper();
        }
    } = null!;

    /// <summary>
    /// Full Name Normalized.
    /// </summary>
    [Required]
    [MaxLength(256)]
    public virtual string FullNameNormalized { get; internal set; } = null!;
}