using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.PolicyHeaders.ContentSecurityPolicy.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger) : BaseController(logger)
{
    /// <summary>
    /// Csp Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("csp")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CspAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok("csp");
    }
}