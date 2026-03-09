using System;
using System.Collections.Generic;

namespace Api.Data.Repository.Includes.Controllers.Response;

/// <summary>
/// Customer Response.
/// </summary>
public class CustomerResponse
{
    /// <summary>
    /// Id.
    /// </summary>
    public virtual Guid Id { get; set; }

    /// <summary>
    /// Profile.
    /// </summary>
    public virtual CustomerProfileResponse Profile { get; set; } = null!;

    /// <summary>
    /// Order.
    /// </summary>
    public virtual ICollection<OrderResponse> Orders { get; set; } = [];
}