using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.Cookies.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger) : BaseController(logger)
{
    private const string COOKIE_KEY = "TestKey";

    /// <summary>
    /// Set Cookie Action.
    /// </summary>
    /// <param name="value">The value to set in cookie.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("set-cookie")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> SetCookieAsync([FromQuery][Required] string value, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        var options = new CookieOptions
        {
            HttpOnly = false,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddMinutes(30)
        };

        this.Response.Cookies
            .Append(COOKIE_KEY, value, options);

        return this.Ok("Cookie set");
    }

    /// <summary>
    /// Get Cookie Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("get-cookie")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> GetCookie(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        var success = this.Request.Cookies
            .TryGetValue(COOKIE_KEY, out var value);

        if (success)
        {
            return Ok($"Cookie value: {value}");
        }

        return Ok("cookie is empty or expired");
    }

    /// <summary>
    /// Delete Cookie Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("delete-cookie")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> DeleteCookie(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        this.Response.Cookies
            .Delete(COOKIE_KEY);
        
        return Ok("Cookie deleted");
    }
}