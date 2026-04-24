using Nano.App.ApiClient.Annotations.Actions;

namespace Api.ApiClients.Service.Models.Api.Requests;

/// <summary>
/// Bad Request Exception Request.
/// </summary>
[GetAction("bad-request-exception")]
public class BadRequestExceptionRequest : BaseCustomsRequest;