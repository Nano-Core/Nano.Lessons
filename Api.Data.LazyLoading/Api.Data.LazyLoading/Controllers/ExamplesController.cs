using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.Data.LazyLoading.Models;
using Api.Data.LazyLoading.Models.Criterias;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;

namespace Api.Data.LazyLoading.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IRepository repository)
    : BaseEntityController<Example, ExampleQueryCriteria>(logger, repository)
{
    /// <summary>
    /// Lazy Loading Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("lazy-loading")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> LazyLoadingAsync(CancellationToken cancellationToken = default)
    {
        var example = await this.Repository
            .GetFirstAsync<Example>(x => true, cancellationToken);

        if (example == null)
        {
            return this.NotFound();
        }

        var lazyloadedRelations = example.Relations;
        var lazyloadedIncludedRelations = example.IncludedRelations;

        return this.Ok(example);
    }
}