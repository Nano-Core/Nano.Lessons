using Api.ApiClients.Service.Models.Api.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Annotations;
using Nano.App.Api.Controllers;
using Nano.App.Exceptions;
using Nano.Common.Consts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.ApiClients.Service.Models.Api.Requests.Models;

namespace Api.ApiClients.Service.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class CustomsController(ILogger<CustomsController> logger) : BaseController(logger)
{
    /// <summary>
    /// Custom Action.
    /// </summary>
    /// <param name="id">The first route parameter.</param>
    /// <param name="type">The second route parameter.</param>
    /// <param name="body">The request body.</param>
    /// <param name="query">The querystring parameter.</param>
    /// <param name="header">The header value</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A custom response.</returns>
    /// <response code="200">Success.</response>
    [HttpPost]
    [Route("{id:guid}/{type}")]
    [Consumes(HttpContentType.JSON)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(CustomResponse), (int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CustomAsync([FromRoute][Required] Guid id, [FromRoute][Required] string type, [FromBody][Required] CustomBody body, [FromQuery][Required] DateTimeOffset query, [FromHeader(Name = "X-Custom-Header")][Required] string header, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok(new CustomResponse
        {
            Id = id,
            Type = type,
            Body = body,
            Query = query,
            Header = header
        });
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
        await Task.CompletedTask;

        return this.Ok(new CustomFileResponse
        {
            Filename = file.FileName
        });
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
    [ProducesResponseType(typeof(CustomFileBodyResponse), (int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CustomFileBodyAsync(IFormFile file, [Required][FromFormBody] CustomFileBody body, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok(new CustomFileBodyResponse
        {
            Filename = file.FileName,
            Body = body
        });
    }

    /// <summary>
    /// Custom Bad Request Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="400">Bad Request.</response>
    [HttpGet]
    [Route("bad-request-exception")]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public virtual async Task<IActionResult> CustomBadRequestExceptionAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new BadRequestException("bad request.", true, true);
    }

    /// <summary>
    /// Custom Problem Details Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="417">Expectation Failed.</response>
    [HttpGet]
    [Route("problem-details-exception")]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType((int)HttpStatusCode.ExpectationFailed)]
    public virtual async Task<IActionResult> CustomProblemDetailsExceptionAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new ProblemDetailsException(new ProblemDetails
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc9110#name-417-expectation-failed",
            Title = "Expectation Failed",
            Status = (int)HttpStatusCode.ExpectationFailed
        });
    }

    /// <summary>
    /// Request Tracing Action.
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
        await Task.CompletedTask;

        return this.Ok(new RequestTracingResponse
        {
            RequestId = this.HttpContext.TraceIdentifier
        });
    }
}