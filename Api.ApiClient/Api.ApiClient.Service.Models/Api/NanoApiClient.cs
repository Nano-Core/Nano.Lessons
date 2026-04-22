using Nano.App.ApiClient;

namespace Api.ApiClient.Service.Models.Api;

/// <summary>
/// Nano Api Client.
/// </summary>
public class NanoApiClient(Nano.App.ApiClient.ApiClient apiClient) : BaseApiClient(apiClient);