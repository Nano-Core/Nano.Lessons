using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Session.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExamplesController(ILogger logger) : BaseController(logger)
{
    private const string SESSION_KEY = "TestKey";

    /// <summary>
    /// Set Session Action.
    /// </summary>
    /// <param name="value">The value to set in session.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("set-session")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> SetSessionAsync([FromQuery][Required]string value, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        this.HttpContext.Session
            .SetString(SESSION_KEY, value);

        return this.Ok("session set");
    }

    /// <summary>
    /// Get Session Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("get-session")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> GetSession(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        var value = this.HttpContext.Session
            .GetString(SESSION_KEY);

        if (value == null)
        {
            return Ok("session is empty or expired");
        }
        
        return Ok($"session value: {value}");
    }

    /// <summary>
    /// Clear Session Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("clear-session")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> ClearSession(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        this.HttpContext.Session
            .Clear();

        return Ok("sesssion cleared");
    }
}