using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Versioning.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
[ApiVersion("1.0")]
[ApiVersion("2.0")]
public class ExamplesController(ILogger logger) : BaseController(logger)
{
    /// <summary>
    /// Version 1.0 (default) Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Ok.</response>
    [HttpGet]
    [Route("versioning")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> Version10Async(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok("v1");
    }

    /// <summary>
    /// Version 2.0 Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Ok.</response>
    [HttpGet]
    [Route("versioning")]
    [MapToApiVersion("2.0")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> Version20Async(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok("v2");
    }
}