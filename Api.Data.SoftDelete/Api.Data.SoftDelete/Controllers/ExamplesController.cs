using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.Data.SoftDelete.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;

namespace Api.Data.SoftDelete.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IRepository repository)
    : BaseEntityController(logger, repository)
{
    /// <summary>
    /// No Save Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("no-save")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> NoSaveAsync(CancellationToken cancellationToken = default)
    {
        await this.Repository
            .AddAsync(new Example
            {
                Name = "name"
            }, cancellationToken);

        return this.Ok("no-save");
    }
}