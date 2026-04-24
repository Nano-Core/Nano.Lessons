using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions.Identity.Authentication.Models;
using Nano.Data.Abstractions.Identity.Extensions;

namespace Api.ApiClients.RootLogIn.Service.Controllers;

/// <summary>
/// Customs Controller.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class CustomsController(ILogger<CustomsController> logger) : BaseController(logger)
{
    /// <summary>
    /// Auto Authenticate Root Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The access token.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("auto-authenticate-root")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> AutoAuthenticateRootAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        var accessToken = this.HttpContext
            .GetJwtToken();

        return this.Ok(new AccessToken
        {
            Token = accessToken!
        });
    }
}