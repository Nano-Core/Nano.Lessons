//using System;
//using Api.Data.EntityEvents.Models;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Nano.Data.Mappings;

//namespace Api.Data.EntityEvents.Data.Mappings;

///// <inheritdoc />
//public class PaymentMapping : BaseEntityMapping<Payment>
//{
//    /// <inheritdoc />
//    public override void Configure(EntityTypeBuilder<Payment> builder)
//    {
//        ArgumentNullException.ThrowIfNull(builder);

//        base.Configure(builder);

//        builder
//            .HasOne(x => x.Order)
//            .WithOne(x => x.Payment)
//            .IsRequired();

//        builder
//            .Property(x => x.Amount)
//            .IsRequired();
//    }
//}