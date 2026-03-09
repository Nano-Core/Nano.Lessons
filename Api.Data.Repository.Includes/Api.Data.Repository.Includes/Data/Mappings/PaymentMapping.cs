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
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        builder
            .HasOne(x => x.Order)
            .WithOne(x => x.Payment);
    }
}