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
    public override void Configure(EntityTypeBuilder<ExampleTrigger> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Trigger)
            .IsRequired();

        builder
            .Property(x => x.ExampleId)
            .IsRequired();
    }
}