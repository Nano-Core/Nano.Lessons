using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.TimeZone.Controllers.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Vivet.AspNetCore.RequestTimeZone;

namespace Api.TimeZone.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExamplesController(ILogger logger) : BaseController(logger)
{
    /// <summary>
    /// Time Zone GET Action.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An object showing different date times.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("timezone")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> TimeZoneAsync([FromQuery][Required]DateTimeOffset dateTime, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        var clientRequestDateTime = TimeZoneInfo.ConvertTime(dateTime, DateTimeInfo.TimeZone.Value!);

        return this.Ok(new
        {
            RequestDateTimeLocal = clientRequestDateTime,
            ServerRecievedUtc = dateTime.UtcDateTime,
            ResponseDateTimeLocal = dateTime,
            DateTimeInfoNow = DateTimeInfo.Now,
            DateTimeInfoUtcNow = DateTimeInfo.UtcNow.UtcDateTime
        });
    }

    /// <summary>
    /// Time Zone POST Action.
    /// </summary>
    /// <param name="request">The date time request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>An object showing different date times.</returns>
    /// <response code="200">Success.</response>
    [HttpPost]
    [Route("timezone")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> TimeZoneAsync([FromBody][Required]DateTimeRequest request, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        var clientRequestDateTime = TimeZoneInfo.ConvertTime(request.DateTime, DateTimeInfo.TimeZone.Value!);

        return this.Ok(new
        {
            RequestDateTimeLocal = clientRequestDateTime,
            ServerRecievedUtc = request.DateTime.UtcDateTime,
            ResponseDateTimeLocal = request.DateTime,
            DateTimeInfoNow = DateTimeInfo.Now,
            DateTimeInfoUtcNow = DateTimeInfo.UtcNow.UtcDateTime
        });
    }
}