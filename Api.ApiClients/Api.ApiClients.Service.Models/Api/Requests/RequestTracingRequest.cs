using Nano.App.ApiClient.Annotations.Actions;

namespace Api.ApiClients.Service.Models.Api.Requests;

/// <summary>
/// Problem Details Exception Request.
/// </summary>
[GetAction("request-tracing")]
public class RequestTracingRequest : BaseCustomsRequest;