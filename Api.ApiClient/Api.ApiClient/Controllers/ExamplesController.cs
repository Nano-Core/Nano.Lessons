using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.ApiClient.Service.Models;
using Api.ApiClient.Service.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.App.ApiClient.Requests;

namespace Api.ApiClient.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="nanoApi">The <see cref="NanoApi"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, NanoApi nanoApi) : BaseController(logger)
{
    /// <summary>
    /// Custom Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("custom")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CustomAsync(CancellationToken cancellationToken = default)
    {
        await nanoApi.Entity
            .IndexAsync<Example>(new IndexRequest(), cancellationToken);

        return this.Ok("custom");
    }
}