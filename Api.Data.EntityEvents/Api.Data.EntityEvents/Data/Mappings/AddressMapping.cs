using System;
using Api.Data.EntityEvents.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.EntityEvents.Data.Mappings;

/// <inheritdoc />
public class AddressMapping : BaseEntityMapping<Address>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Street)
            .IsRequired();

        builder
            .HasOne(x => x.Profile)
            .WithOne(x => x.Address)
            .IsRequired();
    }
}