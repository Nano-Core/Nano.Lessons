using System;
using Api.Data.Repository.Includes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.Repository.Includes.Data.Mappings;

/// <summary>
/// Customer Profile Mapping.
/// </summary>
public class CustomerProfileMapping : BaseEntityMapping<CustomerProfile>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<CustomerProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .HasOne(x => x.Customer)
            .WithOne(x => x.Profile);

        builder
            .Property(x => x.Name)
            .IsRequired();
    }
}