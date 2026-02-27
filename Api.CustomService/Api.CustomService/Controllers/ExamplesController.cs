using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.CustomService.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.CustomService.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="exampleService">The <see cref="IExampleService"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IExampleService exampleService) : BaseController(logger)
{
    private readonly IExampleService exampleService = exampleService ?? throw new ArgumentNullException(nameof(exampleService));

    /// <summary>
    /// Custom Service Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("custom-service")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CustomServiceAsync(CancellationToken cancellationToken = default)
    {
        var message = await this.exampleService
            .GetMessage();

        return this.Ok($"custom-service message: {message}");
    }
}