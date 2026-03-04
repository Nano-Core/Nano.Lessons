using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.Data.MySql.Models;
using Api.Data.MySql.Models.Criterias;
using Nano.Data.Abstractions;

namespace Api.Data.MySql.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IRepository repository) : BaseEntityController<Example, ExampleQueryCriteria>(logger, repository)
{
    /// <summary>
    /// Http Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("http")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> HttpAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        await this.Repository.AddAsync(new Example(), cancellationToken);

        return this.Ok("http");
    }
}

