using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;
using NetTopologySuite.Geometries;

namespace Api.Data.PostgreSQL.Spatial.Models;

/// <summary>
/// Example.
/// </summary>
public class Example : BaseEntity
{
    /// <summary>
    /// Point.
    /// </summary>
    [Required]
    public virtual Point Point { get; set; } = null!;

    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}