using Nano.App.ApiClient;

namespace Api.ApiClients.Audit.Service.Models.ApiClient;

/// <summary>
/// Nano Api Client.
/// </summary>
public class NanoApiClient(Nano.App.ApiClient.ApiClient apiClient) : BaseApiClient(apiClient);