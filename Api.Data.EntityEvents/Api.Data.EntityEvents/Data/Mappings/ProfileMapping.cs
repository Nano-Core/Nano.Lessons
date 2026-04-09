using System;
using Api.Data.EntityEvents.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.EntityEvents.Data.Mappings;

/// <inheritdoc />
public class ProfileMapping : BaseEntityMapping<Profile>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Profile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .HasOne(x => x.Address)
            .WithMany(x => x.Profiles)
            .IsRequired();

        builder
            .HasMany(x => x.Customers)
            .WithOne(x => x.Profile)
            .IsRequired();
    }
}