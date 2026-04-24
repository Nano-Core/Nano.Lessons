using System;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.EntityEvents.Models;

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
    public virtual Customer? Customer { get; set; }
}