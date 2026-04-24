using System;
using Api.Data.MySql.Spatial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;
using NetTopologySuite.Geometries;

namespace Api.Data.MySql.Spatial.Data.Mappings;

/// <summary>
/// Example Mapping.
/// </summary>
public class ExampleMapping : BaseEntityMapping<Example>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Example> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Point)
            .HasColumnType("POINT")
            .HasSpatialReferenceSystem(4326)
            .HasDefaultValue(new Point(0, 0) { SRID = 4326 })
            .IsRequired();

        builder
            .HasIndex(x => x.Point)
            .IsSpatial();

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}