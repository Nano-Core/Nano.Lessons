using System;
using Api.Data.SqlServer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.SqlServer.Data.Mappings;

/// <summary>
/// Example Creatable And Updatable Mapping.
/// </summary>
public class ExampleCreatableAndUpdatableMapping : BaseEntityMapping<ExampleCreatableAndEditable>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<ExampleCreatableAndEditable> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}