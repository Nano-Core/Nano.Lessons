using System;
using Nano.Data.Abstractions.Models;
using Nano.Data.Abstractions.Models.Abstractions;

namespace Api.Data.MySql.StoredProcedures.Models;

/// <summary>
/// Example Result.
/// </summary>
public class ExampleResult : BaseEntityView
{
    /// <summary>
    /// Id.
    /// </summary>
    public virtual Guid Id { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Counter.
    /// </summary>
    public virtual int Counter { get; set; } = 0;
}