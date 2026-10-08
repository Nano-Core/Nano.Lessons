using System;
using Api.Data.SoftDelete.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;
using Nano.Data.Mappings.Extensions;

namespace Api.Data.SoftDelete.Data.Mappings;

/// <summary>
/// Example Mapping.
/// </summary>
public class ExampleMapping : BaseEntityMapping<Example>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<Example> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(x => x.Name);

        builder
            .HasIndex(x => x.Name);

        builder
            .OnDeleting(x =>
            {
                Console.WriteLine("OnDeleting");
            });

        builder
            .OnDeleted(x =>
            {
                Console.WriteLine("OnDeleted");
            });
    }
}