using System;
using Api.ApiClients.Audit.Service.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;
using Nano.Data.Mappings.Extensions;

namespace Api.ApiClients.Audit.Service.Data.Mappings;

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

        builder
            .HasOne(x => x.Navigation)
            .WithMany(x => x.Examples);

        builder
            .OnUpdating(x =>
            {
                x.Entity.Name += "-triggered";
            });
    }
}