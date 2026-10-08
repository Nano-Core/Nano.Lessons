using System;
using Api.Data.LazyLoading.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.LazyLoading.Data.Mappings;

/// <summary>
/// Example Relation Mapping.
/// </summary>
public class ExampleRelationIncludedMapping : BaseEntityMapping<ExampleRelationIncluded>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<ExampleRelationIncluded> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .HasOne(x => x.Example)
            .WithMany(x => x.IncludedRelations)
            .IsRequired();

        builder
            .Property(x => x.Text);
    }
}