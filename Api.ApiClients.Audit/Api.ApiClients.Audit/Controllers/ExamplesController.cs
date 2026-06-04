using Api.ApiClients.Audit.Service.Models.ApiClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.App.ApiClient.Requests;
using Nano.Common.Consts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.ApiClients.Audit.Service.Models;

namespace Api.ApiClients.Audit.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="nanoApiClient">The <see cref="NanoApiClient"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, NanoApiClient nanoApiClient) : BaseController(logger)
{
    private readonly NanoApiClient nanoApiClient = nanoApiClient ?? throw new ArgumentNullException(nameof(nanoApiClient));

    /// <summary>
    /// Creates a single model instance.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created entity.</returns>
    /// <response code="201">Entity created.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="401">Unauthorized.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    [Route(ActionRoutes.CREATE)]
    [Consumes(HttpContentType.JSON)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(Example), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> CreateAsync([FromBody][Required] Example entity, CancellationToken cancellationToken = default)
    {
        var example = await this.nanoApiClient.Entity
            .CreateAsync<Example>(new CreateRequest
            {
                Entity = entity
            }, cancellationToken);

        return this.Created(ActionRoutes.CREATE, example);
    }
}