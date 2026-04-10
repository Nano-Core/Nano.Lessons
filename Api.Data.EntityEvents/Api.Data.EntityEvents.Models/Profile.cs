using Nano.Data.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Data.EntityEvents.Models.Owned;

namespace Api.Data.EntityEvents.Models;

/// <summary>
/// Customer Profile.
/// </summary>
public class Profile : BaseEntity
{
    /// <summary>
    /// Address Id.
    /// </summary>
    [Required]
    public virtual Guid AddressId { get; set; }

    /// <summary>
    /// Address.
    /// </summary>
    public virtual Address? Address { get; set; }

    /// <summary>
    /// Address.
    /// </summary>
    [Required]
    public virtual ProfileSettings Settings { get; set; } = new();

    /// <summary>
    /// Customers.
    /// </summary>
    [Required]
    public virtual ICollection<Customer> Customers { get; set; } = [];
}