using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.Data.MySql.StoredProcedures.Data.Extensions;

namespace Api.Data.MySql.StoredProcedures.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IRepository repository)
    : BaseEntityController(logger, repository)
{
    /// <summary>
    /// Stored Procedure Action.
    /// </summary>
    /// <param name="name">The example name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A result.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("stored-procedure")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> StoredProcedureAsync([Required]string name, CancellationToken cancellationToken = default)
    {
        var result = await this.Repository
            .GetExampleResult(name, cancellationToken);

        return this.Ok(result);
    }
}