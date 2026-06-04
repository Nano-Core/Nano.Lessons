using Nano.Data.Abstractions.Models;

namespace Api.Data.Repository.Includes.Models;

/// <summary>
/// Payment.
/// </summary>
public class Payment : BaseEntity
{
    /// <summary>
    /// Order.
    /// </summary>
    public virtual Order Order { get; set; } = null!;
}