using System;
using Api.Data.Triggers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.Triggers.Data.Mappings;

/// <summary>
/// Example Trigger Mapping.
/// </summary>
public class ExampleTriggerMapping : BaseEntityMapping<ExampleTrigger>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<ExampleTrigger> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(x => x.Trigger)
            .IsRequired();

        builder
            .Property(x => x.ExampleId)
            .IsRequired();
    }
}