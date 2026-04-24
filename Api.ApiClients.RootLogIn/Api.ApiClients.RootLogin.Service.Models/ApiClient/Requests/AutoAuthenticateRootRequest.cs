using Nano.App.ApiClient.Annotations.Actions;

namespace Api.ApiClients.RootLogIn.Service.Models.ApiClient.Requests;

/// <summary>
/// Auto Authenticate Root Request.
/// </summary>
[GetAction("auto-authenticate-root")]
public class AutoAuthenticateRootRequest : BaseCustomsRequest;