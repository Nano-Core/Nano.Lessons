using Nano.App.ApiClient.Requests;

namespace Api.ApiClients.Service.Models.Api.Requests;

/// <summary>
/// Base Customs Request (abstract).
/// </summary>
public abstract class BaseCustomsRequest : BaseRequest
{
    /// <summary>
    /// Constructor.
    /// </summary>
    protected BaseCustomsRequest()
    {
        this.Controller = "customs";
    }
}