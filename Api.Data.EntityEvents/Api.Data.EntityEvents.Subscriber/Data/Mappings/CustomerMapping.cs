using System;
using Api.Data.EntityEvents.Subscriber.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.EntityEvents.Subscriber.Data.Mappings;

/// <summary>
/// Customer Mapping.
/// </summary>
public class CustomerMapping : BaseEntityMapping<Customer>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<Customer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Property(x => x.Identitifer)
            .IsRequired();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .Property(x => x.ProfileId);

        builder
            .Property(x => x.AddressId);

        builder
            .Property(x => x.UseDarkMode)
            .IsRequired();

        builder
            .Property(x => x.Street);
    }
}