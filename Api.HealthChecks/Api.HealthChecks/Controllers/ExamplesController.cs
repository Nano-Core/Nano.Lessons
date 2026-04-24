using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.HealthChecks.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/></param>
/// <param name="healthCheckService">The <see cref="HealthCheckService"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, HealthCheckService healthCheckService)
    : BaseController(logger)
{
    private readonly HealthCheckService healthCheckService = healthCheckService ?? throw new ArgumentNullException(nameof(healthCheckService));

    /// <summary>
    /// Health Check Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    /// <response code="503">Service Unavailable.</response>
    [HttpGet]
    [Route("health-check")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> HealthCheckAsync(CancellationToken cancellationToken = default)
    {
        var report = await this.healthCheckService
            .CheckHealthAsync(cancellationToken);

        var status = report.Status == HealthStatus.Healthy
            ? (int)HttpStatusCode.OK
            : (int)HttpStatusCode.ServiceUnavailable;

        return this.StatusCode(status, new
        {
            status = report.Status.ToString(),
            checks = report.Entries
                .Select(x => new
                {
                    name = x.Key,
                    status = x.Value.Status.ToString(),
                    description = x.Value.Description
                })
        });
    }

    /// <summary>
    /// Webhook Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpPost]
    [Route("webhook")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> WebhookAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok();
    }
}