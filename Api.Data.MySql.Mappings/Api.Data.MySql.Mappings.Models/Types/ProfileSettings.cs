using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Data.MySql.Mappings.Models.Types;

/// <summary>
/// Profile Settings.
/// </summary>
public class ProfileSettings
{
    /// <summary>
    /// Use Dark Mode.
    /// </summary>
    [Required]
    [DefaultValue(false)]
    public virtual bool UseDarkMode { get; set; } = false;

    /// <summary>
    /// Hide Profile Name.
    /// </summary>
    [Required]
    [DefaultValue(false)]
    public virtual bool HideProfileName { get; set; } = false;

    /// <summary>
    /// Email Settings.
    /// </summary>
    [Required]
    public virtual EmailSettings EmailSettings { get; set; } = new();
}