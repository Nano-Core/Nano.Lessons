using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.StartupTasks.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExamplesController(ILogger logger) : BaseController(logger)
{
    /// <summary>
    /// Startup Tasks Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("startup-tasks")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> StartupTaskAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok("startup-tasks");
    }
}