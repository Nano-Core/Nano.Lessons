using System;
using Api.ApiClients.Service.Models.Api.Requests.Models;
using Nano.App.ApiClient.Annotations;
using Nano.App.ApiClient.Annotations.Actions;

namespace Api.ApiClients.Service.Models.Api.Requests;

/// <summary>
/// Custom Request.
/// </summary>
[PostAction("{id}/{type}")]
public class CustomRequest : BaseCustomsRequest
{
    /// <summary>
    /// Id.
    /// </summary>
    [Route(Order = 0)]
    public required Guid Id { get; set; }

    /// <summary>
    /// Type.
    /// </summary>
    [Route(Order = 1)]
    public required string Type { get; set; }

    /// <summary>
    /// Body.
    /// </summary>
    [Body]
    public required CustomBody Body { get; set; }

    /// <summary>
    /// Query.
    /// </summary>
    [Query]
    public required DateTimeOffset Query { get; set; }

    /// <summary>
    /// Header.
    /// </summary>
    [Header(Name = "X-Custom-Header")]
    public required string Header { get; set; }
}