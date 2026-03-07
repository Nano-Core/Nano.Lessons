using Api.Data.Repository.AutoSave.Models;
using Api.Data.Repository.AutoSave.Models.Criterias;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Data.Repository.AutoSave.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IRepository repository)
    : BaseEntityReadOnlyController<Example, ExampleQueryCriteria>(logger, repository)
{
    /// <summary>
    /// Custom Config Section Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("no-save")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CustomConfigSectionAsync(CancellationToken cancellationToken = default)
    {
        await this.Repository
            .AddAsync(new Example
            {
                Name = "name"
            }, cancellationToken);

        return this.Ok("no-save");
    }
}