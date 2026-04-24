using Api.ApiClients.Service.Models.Api;
using Api.ApiClients.Service.Models.Api.Requests;
using Api.ApiClients.Service.Models.Api.Requests.Models;
using Api.ApiClients.Service.Models.Api.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Annotations;
using Nano.App.Api.Controllers;
using Nano.Common.Consts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Nano.App.ApiClient.Models;

namespace Api.ApiClients.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="nanoApiClient">The <see cref="NanoApiClient"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, NanoApiClient nanoApiClient) : BaseController(logger)
{
    private readonly NanoApiClient nanoApiClient = nanoApiClient ?? throw new ArgumentNullException(nameof(nanoApiClient));

    /// <summary>
    /// Custom.
    /// </summary>
    /// <param name="id">The first route parameter.</param>
    /// <param name="type">The second route parameter.</param>
    /// <param name="body">The request body.</param>
    /// <param name="query">The querystring parameter.</param>
    /// <param name="header">The header value</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The custom response.</returns>
    /// <response code="200">Success.</response>
    [HttpPost]
    [Route("custom/{id:guid}/{type}")]
    [Consumes(HttpContentType.JSON)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(CustomResponse), (int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CustomAsync([FromRoute][Required] Guid id, [FromRoute][Required] string type, [FromBody][Required] CustomBody body, [FromQuery][Required] DateTimeOffset query, [FromHeader(Name = "X-Custom-Header")][Required] string header, CancellationToken cancellationToken = default)
    {
        var response = await this.nanoApiClient
            .CustomAsync(new CustomRequest
            {
                Id = id,
                Type = type,
                Body = body,
                Query = query,
                Header = header
            }, cancellationToken);

        if (response == null)
        {
            return this.NotFound();
        }

        return this.Ok(response);
    }

    /// <summary>
    /// Custom File Action.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The custom file response.</returns>
    /// <response code="200">Success.</response>
    [HttpPost]
    [Route("custom/file")]
    [Consumes(HttpContentType.FORM)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(CustomFileResponse), (int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CustomFileAsync(IFormFile file, CancellationToken cancellationToken = default)
    {
        var response = await this.nanoApiClient
            .CustomFileAsync(new CustomFileRequest
            {
                File = new NamedStream
                {
                    Name = file.FileName,
                    Stream = file.OpenReadStream()
                }
            }, cancellationToken);

        if (response == null)
        {
            return this.NotFound();
        }

        return this.Ok(response);
    }

    /// <summary>
    /// Custom File Body Action.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="body">The json body</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The custom file body response.</returns>
    /// <response code="200">Success.</response>
    [HttpPost]
    [Route("custom/file/body")]
    [Consumes(HttpContentType.FORM)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(CustomFileResponse), (int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CustomFileBodyAsync(IFormFile file, [Required][FromFormBody] CustomFileBody body, CancellationToken cancellationToken = default)
    {
        var response = await this.nanoApiClient
            .CustomFileBodyAsync(new CustomFileBodyRequest
            {
                File = new NamedStream
                {
                    Name = file.FileName,
                    Stream = file.OpenReadStream()
                },
                Body = body
            }, cancellationToken);

        if (response == null)
        {
            return this.NotFound();
        }

        return this.Ok(response);
    }

    /// <summary>
    /// Bad Request.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothings.</returns>
    /// <response code="400">Bad Request.</response>
    [HttpGet]
    [Route("bad-request-exception")]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public virtual async Task<IActionResult> BadRequestAsync(CancellationToken cancellationToken = default)
    {
        await this.nanoApiClient
            .BadRequestExceptionAsync(new BadRequestExceptionRequest(), cancellationToken);

        return this.Ok();
    }

    /// <summary>
    /// Problem Details Exception.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothings.</returns>
    /// <response code="417">Expectation Failed.</response>
    [HttpGet]
    [Route("problem-details-exception")]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType((int)HttpStatusCode.ExpectationFailed)]
    public virtual async Task<IActionResult> ProblemDetailsExceptionAsync(CancellationToken cancellationToken = default)
    {
        await this.nanoApiClient
            .ProblemDetailsExceptionAsync(new ProblemDetailsExceptionRequest(), cancellationToken);

        return this.Ok();
    }

    /// <summary>
    /// Request Tracing Exception.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The request tracing response.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("request-tracing")]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(RequestTracingResponse), (int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> RequestTracingAsync(CancellationToken cancellationToken = default)
    {
        var response = await this.nanoApiClient
            .RequestTracingAsync(new RequestTracingRequest(), cancellationToken);

        return this.Ok(response);
    }
}