using System;
using Api.Data.LazyLoading.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.LazyLoading.Data.Mappings;

/// <summary>
/// Example Mapping.
/// </summary>
public class ExampleMapping : BaseEntityMapping<Example>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<Example> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);

        builder
            .HasMany(x => x.Relations)
            .WithOne(x => x.Example)
            .IsRequired();

        builder
            .HasMany(x => x.IncludedRelations)
            .WithOne(x => x.Example)
            .IsRequired();
    }
}