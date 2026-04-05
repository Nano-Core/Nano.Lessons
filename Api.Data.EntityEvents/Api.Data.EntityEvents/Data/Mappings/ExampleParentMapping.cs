using System;
using Api.Data.EntityEvents.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.EntityEvents.Data.Mappings;

/// <summary>
/// Example Parent Mapping.
/// </summary>
public class ExampleParentMapping : BaseEntityMapping<ExampleParent>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleParent> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.ParentName)
            .IsRequired();
    }
}