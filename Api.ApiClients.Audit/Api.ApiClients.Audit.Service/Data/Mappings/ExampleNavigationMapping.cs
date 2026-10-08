using System;
using Api.ApiClients.Audit.Service.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.ApiClients.Audit.Service.Data.Mappings;

/// <summary>
/// Example Navigation Mapping.
/// </summary>
public class ExampleNavigationMapping : BaseEntityMapping<ExampleNavigation>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<ExampleNavigation> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(x => x.NavigationName);
    
        builder
            .HasMany(x => x.Examples)
            .WithOne(x => x.Navigation);
    }
}