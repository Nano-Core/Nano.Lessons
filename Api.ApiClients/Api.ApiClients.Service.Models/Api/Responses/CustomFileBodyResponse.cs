using Api.ApiClients.Service.Models.Api.Requests.Models;

namespace Api.ApiClients.Service.Models.Api.Responses;

/// <summary>
/// Custom File Body Response.
/// </summary>
public class CustomFileBodyResponse : CustomFileResponse
{
    /// <summary>
    /// Body.
    /// </summary>
    public required CustomFileBody Body { get; set; }
}