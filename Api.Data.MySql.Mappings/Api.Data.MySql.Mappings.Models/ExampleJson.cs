using System.ComponentModel.DataAnnotations;
using Api.Data.MySql.Mappings.Models.Types;
using Nano.Data.Abstractions.Models;

namespace Api.Data.MySql.Mappings.Models;

/// <summary>
/// Example Json.
/// </summary>
public class ExampleJson : BaseEntity
{
    /// <summary>
    /// Profile As Json.
    /// </summary>
    [Required]
    public virtual Profile ProfileAsJson { get; set; } = null!;
}