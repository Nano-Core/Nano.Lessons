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
    protected override void ConfigureEntity(EntityTypeBuilder<CustomerProfile> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .HasOne(x => x.Customer)
            .WithOne(x => x.Profile);

        builder
            .Property(x => x.Name)
            .IsRequired();
    }
}