using System;
using Api.Data.EntityEvents.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.EntityEvents.Data.Mappings;

/// <inheritdoc />
public class CustomerMapping : BaseEntityMapping<Customer>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .HasIndex(x => x.Name);

        builder
            .HasOne(x => x.Profile)
            .WithMany(x => x.Customers)
            .IsRequired();

        //builder
        //    .HasMany(x => x.Orders)
        //    .WithOne(x => x.Customer)
        //    .IsRequired();
    }
}