using System;
using Api.Data.EntityEvents.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.EntityEvents.Data.Mappings;

/// <summary>
/// Example Navigation Mapping.
/// </summary>
public class ExampleNavigationMapping : BaseEntityMapping<ExampleNavigation>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<ExampleNavigation> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.NavigationName);

        builder
            .HasMany(x => x.Examples)
            .WithOne(x => x.Navigation)
            .IsRequired();

        builder
            .HasMany(x => x.ExamplesIncluded)
            .WithOne(x => x.NavigationIncluded)
            .IsRequired();
    }
}