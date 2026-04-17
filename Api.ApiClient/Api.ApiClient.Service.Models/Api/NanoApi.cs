using Nano.App.ApiClient;

namespace Api.ApiClient.Service.Models.Api;

/// <summary>
/// Nano Api.
/// </summary>
public class NanoApi(Nano.App.ApiClient.ApiClient apiClient) : BaseApi(apiClient);