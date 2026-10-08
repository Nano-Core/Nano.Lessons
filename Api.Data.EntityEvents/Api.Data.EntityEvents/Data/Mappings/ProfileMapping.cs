using System;
using Api.Data.EntityEvents.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.EntityEvents.Data.Mappings;

/// <inheritdoc />
public class ProfileMapping : BaseEntityMapping<Profile>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<Profile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .HasOne(x => x.Address)
            .WithOne(x => x.Profile);

        builder
            .HasMany(x => x.Customers)
            .WithOne(x => x.Profile)
            .IsRequired();

        builder
            .OwnsOne(x => x.Settings)
            .Property(x => x.UseDarkMode)
            .IsRequired();
    }
}