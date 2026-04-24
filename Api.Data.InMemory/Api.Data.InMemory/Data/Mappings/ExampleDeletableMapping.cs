using System;
using Api.Data.InMemory.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.InMemory.Data.Mappings;

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