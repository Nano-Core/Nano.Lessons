using Nano.App.ApiClient.Annotations.Actions;

namespace Api.ApiClients.Service.Models.Api.Requests;

/// <summary>
/// Problem Details Exception Request.
/// </summary>
[GetAction("problem-details-exception")]
public class ProblemDetailsExceptionRequest : BaseCustomsRequest;