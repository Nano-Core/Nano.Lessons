using System;
using Api.Data.Triggers.Data.Triggers;
using Api.Data.Triggers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;
using Nano.Data.Mappings.Extensions;

namespace Api.Data.Triggers.Data.Mappings;

/// <summary>
/// Example Mapping.
/// </summary>
public class ExampleMapping : BaseEntityMapping<Example>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Example> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);

        builder
            .Property(x => x.UpdatedAt);

        builder
            .HasIndex(x => x.UpdatedAt);

        builder
            .OnInserting(ExampleTriggers.Inserting);

        builder
            .OnInserted(ExampleTriggers.Inserted);

        builder
            .OnUpdating(ExampleTriggers.Updating);

        builder
            .OnUpdated(ExampleTriggers.Updated);

        builder
            .OnDeleting(ExampleTriggers.Deleting);

        builder
            .OnDeleted(ExampleTriggers.Deleted);
    }
}