//using System;
//using System.ComponentModel.DataAnnotations;
//using Nano.Data.Abstractions.Eventing.Annotations;
//using Nano.Data.Abstractions.Models;

//namespace Api.Data.EntityEvents.Models;

///// <summary>
///// Order.
///// </summary>
//[Publish(
//    nameof(CustomerId),
//    nameof(ReferenceNumber),
//    $"{nameof(Customer)}.{nameof(Customer.Name)}",
//    $"{nameof(Payment)}.{nameof(Payment.Amount)}")]
//public class Order : BaseEntity
//{
//    /// <summary>
//    /// Customer Id.
//    /// </summary>
//    [Required]
//    public virtual Guid CustomerId { get; set; }

//    /// <summary>
//    /// Customer.
//    /// </summary>
//    public virtual Customer? Customer { get; set; }

//    /// <summary>
//    /// Reference Number.
//    /// </summary>
//    [Required]
//    public virtual string ReferenceNumber { get; set; } = null!;

//    /// <summary>
//    /// Payment Id.
//    /// </summary>
//    public virtual Guid? PaymentId { get; set; }

//    /// <summary>
//    /// Payment.
//    /// </summary>
//    public virtual Payment? Payment { get; set; }
//}