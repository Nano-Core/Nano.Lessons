using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.PolicyHeaders.ForwardedHeaders.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExamplesController(ILogger logger) : BaseController(logger)
{
    /// <summary>
    /// Forwarded Headers Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("forwarded-headers")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> ForwardedHeadersAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return Ok(new
        {
            RemoteIp = HttpContext.Connection.RemoteIpAddress?.ToString(),
            HttpContext.Request.Scheme,
            Host = HttpContext.Request.Host.Value,
            OriginalHeaders = HttpContext.Request.Headers
                .Where(x => x.Key.StartsWith("X-Original"))
                .ToDictionary(x => x.Key, x => x.Value.ToString())
        });
    }
}