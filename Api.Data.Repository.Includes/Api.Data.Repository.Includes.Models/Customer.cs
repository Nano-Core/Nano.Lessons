using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Annotations;
using Nano.Data.Abstractions.Config.Enums;
using Nano.Data.Abstractions.Models;

namespace Api.Data.Repository.Includes.Models;

/// <summary>
/// Customer.
/// </summary>
public class Customer : BaseEntity
{
    /// <summary>
    /// Profile Id.
    /// </summary>
    [Required]
    public virtual Guid ProfileId { get; set; }

    /// <summary>
    /// Profile.
    /// </summary>
    public virtual CustomerProfile Profile { get; set; } = null!;

    /// <summary>
    /// Order.
    /// </summary>
    [Required]
    [Include(QuerySplitBehavior.SplitQuery)]
    public virtual ICollection<Order> Orders { get; set; } = [];
}