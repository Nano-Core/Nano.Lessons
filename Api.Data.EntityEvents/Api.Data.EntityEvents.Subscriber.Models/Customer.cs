using System;
using System.ComponentModel.DataAnnotations;
using Nano.Data.Abstractions.Eventing.Annotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.EntityEvents.Subscriber.Models;

/// <summary>
/// Customer.
/// </summary>
[Subscribe]
public class Customer : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    public virtual string Identitifer { get; set; } = null!;

    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Profile Id.
    /// </summary>
    [Required]
    public virtual Guid ProfileId { get; set; }

    /// <summary>
    /// Address Id.
    /// </summary>
    public virtual Guid? AddressId { get; set; }

    /// <summary>
    /// Use Dark Mode.
    /// </summary>
    [Required]
    public virtual bool UseDarkMode { get; set; } = false;

    /// <summary>
    /// Street.
    /// </summary>
    public virtual string? Street { get; set; }
}