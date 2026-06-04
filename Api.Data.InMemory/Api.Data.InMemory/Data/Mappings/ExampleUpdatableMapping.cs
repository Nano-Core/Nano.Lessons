using System;
using Api.Data.InMemory.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.InMemory.Data.Mappings;

/// <summary>
/// Example Updatable Mapping.
/// </summary>
public class ExampleUpdatableMapping : BaseEntityMapping<ExampleUpdatable>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleUpdatable> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}