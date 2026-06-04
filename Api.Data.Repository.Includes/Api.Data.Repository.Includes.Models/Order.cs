using System;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Annotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.Repository.Includes.Models;

/// <summary>
/// Order.
/// </summary>
public class Order : BaseEntity
{
    /// <summary>
    /// Customer Id.
    /// </summary>
    [Required]
    public virtual Guid CustomerId { get; set; }

    /// <summary>
    /// Customer.
    /// </summary>
    public virtual Customer Customer { get; set; } = null!;

    /// <summary>
    /// Payment Id.
    /// </summary>
    public virtual Guid? PaymentId { get; set; }

    /// <summary>
    /// Payment.
    /// </summary>
    [Include]
    public virtual Payment? Payment { get; set; }
}