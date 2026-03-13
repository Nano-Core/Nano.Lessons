using System;
using Api.Data.MySql.Mappings.Models;
using Api.Data.MySql.Mappings.Models.Types;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;
using Newtonsoft.Json;

namespace Api.Data.MySql.Mappings.Data.Mappings;

/// <summary>
/// Example Json Mapping.
/// </summary>
public class ExampleJsonMapping : BaseEntityMapping<ExampleJson>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleJson> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.ProfileAsJson)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<Profile>(x)!);
    }
}