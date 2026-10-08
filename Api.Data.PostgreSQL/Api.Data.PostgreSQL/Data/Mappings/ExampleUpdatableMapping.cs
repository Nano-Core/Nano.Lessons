using System;
using Api.Data.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.PostgreSQL.Data.Mappings;

/// <summary>
/// Example Updatable Mapping.
/// </summary>
public class ExampleUpdatableMapping : BaseEntityMapping<ExampleUpdatable>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<ExampleUpdatable> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}