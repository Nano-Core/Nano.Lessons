using System;
using Api.Data.Repository.Includes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nano.Data.Mappings;

namespace Api.Data.Repository.Includes.Data.Mappings;

/// <summary>
/// Example Mapping.
/// </summary>
public class PaymentMapping : BaseEntityMapping<Payment>
{
    /// <inheritdoc />
    protected override void ConfigureEntity(EntityTypeBuilder<Payment> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .HasOne(x => x.Order)
            .WithOne(x => x.Payment);
    }
}