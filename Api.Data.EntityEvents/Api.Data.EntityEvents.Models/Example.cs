using Nano.Data.Abstractions.Eventing.Annotations;
using Nano.Data.Abstractions.Models;

namespace Api.Data.EntityEvents.Models;

/// <summary>
/// Example.
/// </summary>
[Publish(nameof(this.Name))]
public class Example : BaseEntity
{
    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;
}

// BUG: Make navigation to test 