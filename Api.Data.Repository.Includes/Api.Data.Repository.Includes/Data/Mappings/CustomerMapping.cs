using System;
using Api.Data.Repository.Includes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.Repository.Includes.Data.Mappings;

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
            .HasOne(x => x.Profile)
            .WithOne(x => x.Customer)
            .IsRequired();

        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.Customer)
            .IsRequired();
    }
}