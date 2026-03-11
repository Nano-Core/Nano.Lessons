using System;
using Api.Data.SqlServer.Spatial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.SqlServer.Spatial.Data.Mappings;

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
            .HasColumnType("geography")
            .IsRequired();

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}