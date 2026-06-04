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
    public override void Configure(EntityTypeBuilder<ExampleDeletable> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}