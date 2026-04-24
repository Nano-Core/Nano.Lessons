using System;

namespace Api.Data.MySql.Mappings.Models.Types;

/// <summary>
/// Profile Picture.
/// </summary>
public class ProfilePicture
{
    /// <summary>
    /// Text.
    /// </summary>
    public virtual Guid Id { get; set; }

    /// <summary>
    /// Text.
    /// </summary>
    public virtual string? Path { get; set; }
}