using System.ComponentModel.DataAnnotations;

namespace Api.MultipartJson.Controllers.Requests;

/// <summary>
/// Json Body.
/// </summary>
public class JsonBody
{
    /// <summary>
    /// Text.
    /// </summary>
    [Required]
    public string Text { get; set; } = null!;
}