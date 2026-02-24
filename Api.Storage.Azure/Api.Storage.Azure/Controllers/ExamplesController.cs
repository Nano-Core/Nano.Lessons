using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.Storage.Azure.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger) : BaseController(logger)
{
    /// <summary>
    /// Http Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("http")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> HttpAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok("http");
    }
}