using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Data.MySql.Mappings.Models.Types;

/// <summary>
/// Email Settings.
/// </summary>
public class EmailSettings
{
    /// <summary>
    /// Marketing.
    /// </summary>
    [Required]
    [DefaultValue(false)]
    public virtual bool Marketing { get; set; } = false;

    /// <summary>
    /// System.
    /// </summary>
    [Required]
    [DefaultValue(false)]
    public virtual bool System { get; set; } = true;
}