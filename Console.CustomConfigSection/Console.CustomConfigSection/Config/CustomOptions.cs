using System.ComponentModel.DataAnnotations;

namespace Console.CustomConfigSection.Config;

/// <summary>
/// Custom Options.
/// </summary>
public class CustomOptions
{
    internal static string SectionName => "Custom";

    /// <summary>
    /// Value.
    /// </summary>
    [Required]
    public virtual string Value { get; set; } = null!;
}