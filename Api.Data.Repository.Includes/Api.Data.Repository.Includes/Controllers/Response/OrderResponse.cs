using System;

namespace Api.Data.Repository.Includes.Controllers.Response;

/// <summary>
/// Order Response.
/// </summary>
public class OrderResponse
{
    /// <summary>
    /// Id.
    /// </summary>
    public virtual Guid Id { get; set; }

    /// <summary>
    /// Customer.
    /// </summary>
    public virtual CustomerResponse Customer { get; set; } = null!;

    /// <summary>
    /// Payment.
    /// </summary>
    public virtual PaymentResponse? Payment { get; set; }
}