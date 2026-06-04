using System.ComponentModel.DataAnnotations;

namespace Api.ApiClients.Service.Models.Api.Requests.Models;

/// <summary>
/// Custom File Body.
/// </summary>
public class CustomFileBody
{
    /// <summary>
    /// Text.
    /// </summary>
    [Required]
    public string Text { get; set; } = null!;
}