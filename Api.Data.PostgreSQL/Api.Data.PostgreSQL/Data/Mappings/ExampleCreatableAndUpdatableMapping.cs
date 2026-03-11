using System;
using Api.Data.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.PostgreSQL.Data.Mappings;

/// <summary>
/// Example Creatable And Updatable Mapping.
/// </summary>
public class ExampleCreatableAndUpdatableMapping : BaseEntityMapping<ExampleCreatableAndEditable>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleCreatableAndEditable> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}