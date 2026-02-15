using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.ErrorHandling.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExamplesController(ILogger logger) : BaseController(logger)
{
    /// <summary>
    /// Error Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="500">Error.</response>
    [HttpGet]
    [Route("error")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> ContentTypeAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new Exception("An error occured.");
    }
}