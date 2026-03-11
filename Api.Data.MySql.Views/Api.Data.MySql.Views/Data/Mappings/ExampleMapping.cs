using System;
using Api.Data.MySql.Views.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.MySql.Views.Data.Mappings;

/// <summary>
/// Example Mapping.
/// </summary>
public class ExampleMapping : BaseEntityViewMapping<Example>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Example> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        // BUG: Could we have a base class for 
        // Or we need to figure out how a user would make a view with no Id. Is that possible?

        builder
            .Property(x => x.Id);

        builder
            .Property(x => x.CreatedAt);

        builder
            .Property(x => x.Name);
    }
}