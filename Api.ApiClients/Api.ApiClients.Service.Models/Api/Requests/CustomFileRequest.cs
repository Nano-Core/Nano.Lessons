using Nano.App.ApiClient.Annotations;
using Nano.App.ApiClient.Annotations.Actions;
using Nano.App.ApiClient.Models;

namespace Api.ApiClients.Service.Models.Api.Requests;

/// <summary>
/// Custom File Request.
/// </summary>
[PostAction("custom/file")]
public class CustomFileRequest : BaseCustomsRequest
{
    /// <summary>
    /// File.
    /// </summary>
    [Form]
    public required NamedStream File { get; set; }
}