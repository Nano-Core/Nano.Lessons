using System;
using Api.Data.LazyLoading.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.LazyLoading.Data.Mappings;

/// <summary>
/// Example Relation Mapping.
/// </summary>
public class ExampleRelationMapping : BaseEntityMapping<ExampleRelation>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleRelation> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .HasOne(x => x.Example)
            .WithMany(x => x.Relations)
            .IsRequired();

        builder
            .Property(x => x.Text);
    }
}