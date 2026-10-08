using System;
using Api.Data.PostgreSQL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.PostgreSQL.Data.Mappings;

/// <summary>
/// Example Deletable Mapping.
/// </summary>
public class ExampleDeletableMapping : BaseEntityMapping<ExampleDeletable>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<ExampleDeletable> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}