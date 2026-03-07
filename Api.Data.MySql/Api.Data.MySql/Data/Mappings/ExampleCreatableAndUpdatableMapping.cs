using System;
using Api.Data.MySql.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.MySql.Data.Mappings;

/// <summary>
/// Example Creatable And Updatable Mapping.
/// </summary>
public class ExampleCreatableAndUpdatableMapping : BaseEntityMapping<ExampleCreatableAndUpdatable>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleCreatableAndUpdatable> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}