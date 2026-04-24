using Api.ApiClients.Service.Models.Api.Requests.Models;
using Nano.App.ApiClient.Annotations;
using Nano.App.ApiClient.Annotations.Actions;
using Nano.App.ApiClient.Models;

namespace Api.ApiClients.Service.Models.Api.Requests;

/// <summary>
/// Custom File Body Request.
/// </summary>
[PostAction("custom/file/body")]
public class CustomFileBodyRequest : BaseCustomsRequest
{
    /// <summary>
    /// File.
    /// </summary>
    [Form]
    public required NamedStream File { get; set; }

    /// <summary>
    /// Body.
    /// </summary>
    [Form]
    public required CustomFileBody Body { get; set; }
}