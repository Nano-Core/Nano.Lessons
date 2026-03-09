using System;

namespace Api.Data.Repository.Includes.Controllers.Response;

/// <summary>
/// Customer Profile Response.
/// </summary>
public class CustomerProfileResponse
{
    /// <summary>
    /// Id.
    /// </summary>
    public virtual Guid Id { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}