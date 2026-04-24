using Api.ApiClients.Service.Models.Api.Requests;
using System;
using Api.ApiClients.Service.Models.Api.Requests.Models;

namespace Api.ApiClients.Service.Models.Api.Responses;

/// <summary>
/// Custom Response.
/// </summary>
public class CustomResponse
{
    /// <summary>
    /// Id.
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// Type.
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// Body.
    /// </summary>
    public required CustomBody Body { get; set; }

    /// <summary>
    /// Query.
    /// </summary>
    public required DateTimeOffset? Query { get; set; }

    /// <summary>
    /// Header.
    /// </summary>
    public required string Header { get; set; }
}