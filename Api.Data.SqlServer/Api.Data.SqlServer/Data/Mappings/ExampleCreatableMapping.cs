using System;
using Api.Data.SqlServer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.SqlServer.Data.Mappings;

/// <summary>
/// Example Creatable Mapping.
/// </summary>
public class ExampleCreatableMapping : BaseEntityMapping<ExampleCreatable>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleCreatable> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);
    }
}