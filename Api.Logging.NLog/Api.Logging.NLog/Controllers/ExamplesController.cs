using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.Logging.NLog.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger) : BaseController(logger)
{
    /// <summary>
    /// Logging Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("logging")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> LoggingAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        this.Logger
            .LogDebug("Debug");

        this.Logger
            .LogInformation("Information");

        this.Logger
            .LogWarning("Warning");

        this.Logger
            .LogError("Error");

        return this.Ok("logging");
    }

    /// <summary>
    /// Logging Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("logging-exception")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> LoggingExceptionAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new Exception("test error");
    }
}