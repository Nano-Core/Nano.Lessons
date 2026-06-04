using System;
using Api.Data.InMemory.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.InMemory.Data.Mappings;

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