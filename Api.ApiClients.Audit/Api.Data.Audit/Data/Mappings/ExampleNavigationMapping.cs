using System;
using Api.Data.Audit.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.Audit.Data.Mappings;

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
            .WithOne(x => x.Navigation);
    }
}