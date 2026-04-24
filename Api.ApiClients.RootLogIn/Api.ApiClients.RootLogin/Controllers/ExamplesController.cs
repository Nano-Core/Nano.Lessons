using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.ApiClients.RootLogIn.Service.Models.ApiClient;
using Api.ApiClients.RootLogIn.Service.Models.ApiClient.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Common.Consts;
using Nano.Data.Abstractions.Identity.Authentication.Models;

namespace Api.ApiClients.RootLogIn.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="nanoApiClient">The <see cref="NanoApiClient"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, NanoApiClient nanoApiClient) : BaseController(logger)
{
    private readonly NanoApiClient nanoApiClient = nanoApiClient ?? throw new ArgumentNullException(nameof(nanoApiClient));

    /// <summary>
    /// Auto Authenticate Root.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The access token.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("auto-authenticate-root")]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(AccessToken), (int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> AutoAuthenticateRootAsync(CancellationToken cancellationToken = default)
    {
        var response = await this.nanoApiClient
            .AutoAuthenticateRootAsync(new AutoAuthenticateRootRequest(), cancellationToken);

        return this.Ok(response);
    }
}