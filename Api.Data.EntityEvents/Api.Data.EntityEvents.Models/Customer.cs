using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Api.Data.EntityEvents.Models.Owned;
using Nano.Data.Abstractions.Annotations;
using Nano.Data.Abstractions.Eventing.Annotations;

namespace Api.Data.EntityEvents.Models;

/// <summary>
/// Customer.
/// </summary>
[Publish(
    nameof(Name),
    nameof(ProfileId),
    $"{nameof(Profile)}.{nameof(Profile.AddressId)}",
    $"{nameof(Profile)}.{nameof(Profile.Settings)}.{nameof(ProfileSettings.UseDarkMode)}",
    $"{nameof(Profile)}.{nameof(Profile.Address)}.{nameof(Address.Street)}")]
public class Customer : Person
{
    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Profile Id.
    /// </summary>
    public virtual Guid? ProfileId { get; set; }

    /// <summary>
    /// Profile.
    /// </summary>
    [Include]
    public virtual Profile? Profile { get; set; }

    ///// <summary>
    ///// Profile.
    ///// </summary>
    //[Required]
    //public virtual ICollection<Order> Orders { get; set; } = [];
}