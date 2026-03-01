using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.Eventing.RabbitMq.Eventing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Eventing.Abstractions;

namespace Api.Eventing.RabbitMq.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="eventing">The <see cref="IEventing"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IEventing eventing) : BaseController(logger)
{
    /// <summary>
    /// Eventing Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("eventing")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> EventingAsync(CancellationToken cancellationToken = default)
    {
        await eventing
            .PublishAsync(new EventModel
            {
                Text = "Testing eventing"
            }, cancellationToken: cancellationToken);

        return this.Ok("eventing");
    }

    /// <summary>
    /// Eventing with Routing Key Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("eventing-routing-key")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> EventingRoutingKeyAsync(CancellationToken cancellationToken = default)
    {
        await eventing
            .PublishAsync(new EventModel
            {
                Text = "Testing eventing"
            }, cancellationToken: cancellationToken);

        return this.Ok("eventing-routing-key");
    }
}