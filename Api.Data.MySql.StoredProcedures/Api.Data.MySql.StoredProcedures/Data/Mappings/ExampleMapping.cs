using System;
using Api.Data.MySql.Views.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.MySql.Views.Data.Mappings;

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
    }
}