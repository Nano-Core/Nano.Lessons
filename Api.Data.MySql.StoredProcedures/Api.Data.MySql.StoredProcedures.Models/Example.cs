using Nano.Data.Abstractions.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Data.MySql.StoredProcedures.Models;

/// <summary>
/// Example.
/// </summary>
public class Example : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    [DefaultValue(0)]
    public virtual int Counter { get; set; } = 0;
}