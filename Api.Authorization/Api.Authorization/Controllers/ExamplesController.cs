using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.Authorization.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger) : BaseController(logger)
{
    /// <summary>
    /// Authenticated Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("authenticated")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> AuthenticatedAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok("authenticated");
    }

    /// <summary>
    /// Forbidden Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="401">Unauthorized.</response>
    [HttpGet]
    [Route("forbidden")]
    [Authorize(Policy = "CustomPolicy")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> ForbiddenAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok("forbidden");
    }
}