using System;
using Api.Data.Repository.Includes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.Repository.Includes.Data.Mappings;

/// <summary>
/// Example Mapping.
/// </summary>
public class OrderMapping : BaseEntityMapping<Order>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .IsRequired();

        builder
            .HasOne(x => x.Payment)
            .WithOne(x => x.Order);
    }
}