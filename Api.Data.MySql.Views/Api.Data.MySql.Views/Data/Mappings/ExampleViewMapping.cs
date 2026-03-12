using System;
using Api.Data.MySql.Views.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.MySql.Views.Data.Mappings;

/// <summary>
/// Example Mapping.
/// </summary>
public class ExampleViewMapping : BaseEntityViewMapping<ExampleView>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleView> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Id);

        builder
            .Property(x => x.CreatedAt);

        builder
            .Property(x => x.Name);

        builder
            .Property(x => x.NameLength);
    }
}