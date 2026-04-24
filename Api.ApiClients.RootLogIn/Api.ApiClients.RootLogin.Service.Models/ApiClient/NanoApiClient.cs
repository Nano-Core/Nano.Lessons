using System.Threading;
using System.Threading.Tasks;
using Api.ApiClients.RootLogIn.Service.Models.ApiClient.Requests;
using Nano.App.ApiClient;
using Nano.Data.Abstractions.Identity.Authentication.Models;

namespace Api.ApiClients.RootLogIn.Service.Models.ApiClient;

/// <summary>
/// Nano Api Client.
/// </summary>
public class NanoApiClient(Nano.App.ApiClient.ApiClient apiClient) : BaseApiClient(apiClient)
{
    /// <summary>
    /// Auto Authenticate Root Async.
    /// </summary>
    /// <param name="request">The <see cref="AutoAuthenticateRootRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="AccessToken"/>.</returns>
    public Task<AccessToken?> AutoAuthenticateRootAsync(AutoAuthenticateRootRequest request, CancellationToken cancellationToken = default)
    {
        return this.InvokeAsync<AutoAuthenticateRootRequest, AccessToken>(request, cancellationToken);
    }
}