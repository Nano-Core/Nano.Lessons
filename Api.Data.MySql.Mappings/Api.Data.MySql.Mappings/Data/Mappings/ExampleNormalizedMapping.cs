using Api.Data.MySql.Mappings.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;
using System;

namespace Api.Data.MySql.Mappings.Data.Mappings;

/// <summary>
/// Example Normalized Mapping.
/// </summary>
public class ExampleNormalizedMapping : BaseEntityMapping<ExampleNormalized>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleNormalized> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(x => x.LastName)
            .HasMaxLength(128)
            .IsRequired();

        builder
            .Property(x => x.FullName)
            .HasMaxLength(256)
            .IsRequired();

        builder
            .Property(x => x.FullNameNormalized)
            .HasMaxLength(256)
            .IsRequired();

        builder
            .HasIndex(x => x.FullNameNormalized)
            .IsUnique();
    }
}