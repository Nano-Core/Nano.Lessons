using System;
using Api.Data.MySql.Mappings.Data.Mappings.Extensions;
using Api.Data.MySql.Mappings.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.MySql.Mappings.Data.Mappings;

/// <summary>
/// Example Owned Mapping.
/// </summary>
public class ExampleOwnedMapping : BaseEntityMapping<ExampleOwned>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleOwned> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .MapType(x => x.Profile);
    }
}