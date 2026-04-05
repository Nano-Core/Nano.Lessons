using Nano.Data.Abstractions.Eventing.Annotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.EntityEvents.Subscriber.Models;

/// <summary>
/// Example.
/// </summary>
[Subscribe]
public class Example : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}