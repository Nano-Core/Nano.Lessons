using System.ComponentModel.DataAnnotations;

namespace Api.Data.EntityEvents.Models.Owned;

/// <summary>
/// Profile Settings
/// </summary>
public class ProfileSettings
{
    /// <summary>
    /// Use Dark Mode.
    /// </summary>
    [Required]
    public virtual bool UseDarkMode { get; set; } = false;
}