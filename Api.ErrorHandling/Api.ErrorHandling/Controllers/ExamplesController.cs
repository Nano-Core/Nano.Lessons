using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.App.Exceptions;
using Nano.Data.Abstractions.Identity.Exceptions;
using Vivet.AspNetCore.RequestVirusScan.Exceptions;
using Vivet.AspNetCore.RequestVirusScan.Models.Enums;

namespace Api.ErrorHandling.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExamplesController(ILogger logger) : BaseController(logger)
{
    /// <summary>
    /// Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="500">Error.</response>
    [HttpGet]
    [Route("exception")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> ExceptionAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new Exception("error");
    }

    /// <summary>
    /// Aggregate Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="408">Request Timeout.</response>
    [HttpGet]
    [Route("exception-aggregate")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> AggregateAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new AggregateException("error-aggregate", new Exception("inner exception"));
    }

    /// <summary>
    /// Virus Scan Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="400">Bad Request.</response>
    [HttpGet]
    [Route("exception-virus-scan")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public virtual async Task<IActionResult> VirusScanAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new VirusScanException(ResultType.VirusFound, "file.exe", "Dangerous Virus");
    }

    /// <summary>
    /// Unauthorized Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="401">Unauthorized.</response>
    [HttpGet]
    [Route("exception-unauthorized")]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<IActionResult> UnauthorizedAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new UnauthorizedException();
    }

    /// <summary>
    /// Permission Denied Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="403">Forbidden.</response>
    [HttpGet]
    [Route("exception-permission-denied")]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public virtual async Task<IActionResult> PermissionDeniedAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new PermissionDeniedException();
    }

    /// <summary>
    /// Identity Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="400">Bad Request.</response>
    [HttpGet]
    [Route("exception-identity")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public virtual async Task<IActionResult> IdentityAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new IdentityException("error");
    }

    /// <summary>
    /// Bad Request Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="400">Bad Request.</response>
    [HttpGet]
    [Route("exception-bad-request")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public virtual async Task<IActionResult> BadRequestAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new BadRequestException("error");
    }

    /// <summary>
    /// Bad Request (Coded) Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="400">Bad Request.</response>
    [HttpGet]
    [Route("exception-bad-request-coded")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public virtual async Task<IActionResult> BadRequestCodedAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new BadRequestException("error-coded", true);
    }

    /// <summary>
    /// Bad Request (Translated) Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="400">Bad Request.</response>
    [HttpGet]
    [Route("exception-bad-request-translated")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public virtual async Task<IActionResult> BadRequestTranslatedAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new BadRequestException("error-translated", false, true);
    }

    /// <summary>
    /// Task Canceled Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="408">Request Timeout.</response>
    [HttpGet]
    [Route("exception-task-canceled")]
    [ProducesResponseType((int)HttpStatusCode.RequestTimeout)]
    public virtual async Task<IActionResult> TaskCanceledAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new TaskCanceledException("error-task-cancelled");
    }

    /// <summary>
    /// Operation Cancelled Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="408">Request Timeout.</response>
    [HttpGet]
    [Route("exception-operation-canceled")]
    [ProducesResponseType((int)HttpStatusCode.RequestTimeout)]
    public virtual async Task<IActionResult> OperationCancelledAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new OperationCanceledException("error-operation-cancelled");
    }

    /// <summary>
    /// Problem Details Exception Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Nothing.</returns>
    /// <response code="508">Loop Detected.</response>
    [HttpGet]
    [Route("exception-problem-details")]
    [ProducesResponseType((int)HttpStatusCode.LoopDetected)]
    public virtual async Task<IActionResult> ProblemDetailsAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        throw new ProblemDetailsException(new ProblemDetails
        {
            Status = (int)HttpStatusCode.LoopDetected,
            Title = "Loop Detected",
            Detail = "Error"
        });
    }

    /// <summary>
    /// Bad Request Validation Action.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="500">Error.</response>
    [HttpGet]
    [Route("validation-error")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> BadRequestValidationAsync([FromQuery][Required]string value, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok();
    }
}