using System.ComponentModel.DataAnnotations;

namespace Api.Data.MySql.Mappings.Models.Types;

/// <summary>
/// Profile.
/// </summary>
public class Profile
{
    /// <summary>
    /// Text.
    /// </summary>
    public virtual string? Text { get; set; }

    /// <summary>
    /// Picture.
    /// </summary>
    public virtual ProfilePicture? Picture { get; set; }

    /// <summary>
    /// Settings.
    /// </summary>
    [Required]
    public virtual ProfileSettings Settings { get; set; } = new();
}