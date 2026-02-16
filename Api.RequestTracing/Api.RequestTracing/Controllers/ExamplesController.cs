using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.RequestTracing.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExamplesController(ILogger logger) : BaseController(logger)
{
    /// <summary>
    /// Request Tracing Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("request-tracing")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> RequestTracingAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok(new
        {
            this.RequestId
        });
    }
}