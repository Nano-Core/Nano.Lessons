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
    protected override void ConfigureEntity(EntityTypeBuilder<ExampleOwned> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .MapType(x => x.Profile);
    }
}