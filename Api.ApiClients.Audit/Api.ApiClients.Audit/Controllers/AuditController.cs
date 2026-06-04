using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.ApiClients.Audit.Service.Models.ApiClient;
using Api.ApiClients.Audit.Service.Models.Criterias;
using DynamicExpression.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.App.ApiClient.Requests;
using Nano.Common.Consts;
using Nano.Data.Abstractions.Models;

namespace Api.ApiClients.Audit.Controllers;

/// <summary>
/// Controller with audit.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="nanoApiClient">The <see cref="NanoApiClient"/>.</param>
public class AuditController(ILogger<ExamplesController> logger, NanoApiClient nanoApiClient)
    : BaseController(logger)
{
    private readonly NanoApiClient nanoApiClient = nanoApiClient ?? throw new ArgumentNullException(nameof(nanoApiClient));

    /// <summary>
    /// Gets all entities matching the specified query.
    /// </summary>
    /// <param name="query">The query used to filter entities.</param>
    /// <param name="includeDepth">Optional include depth for related entities.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of entities matching the query.</returns>
    /// <response code="200">Entities retrieved successfully.</response>
    /// <response code="400">Invalid query parameters.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="404">No entities found.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    [Route(ActionRoutes.INDEX)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(IEnumerable<AuditEntry>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> IndexAsync([FromQuery][Required] IQuery query, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    {
        var examples = await this.nanoApiClient.Audit
            .IndexAsync(new IndexRequest
            {
                IncludeDepth = includeDepth
            }, cancellationToken);

        return this.Ok(examples);
    }

    /// <summary>
    /// Gets a single entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <param name="includeDepth">Optional include depth for related entities.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The entity matching the identifier.</returns>
    /// <response code="200">Entity retrieved successfully.</response>
    /// <response code="400">Invalid identifier.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="404">Entity not found.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet]
    [Route(ActionRoutes.DETAILS)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(AuditEntry), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> DetailsAsync([FromRoute][Required] Guid id, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    {
        var examples = await this.nanoApiClient.Audit
            .DetailsAsync(new DetailsRequest
            {
                Id = id,
                IncludeDepth = includeDepth
            }, cancellationToken);

        return this.Ok(examples);
    }

    /// <summary>
    /// Gets multiple entities by their identifiers.
    /// </summary>
    /// <param name="ids">The identifiers of the entities.</param>
    /// <param name="includeDepth">Optional include depth for related entities.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The entities matching the identifiers.</returns>
    /// <response code="200">Entities retrieved successfully.</response>
    /// <response code="400">Invalid identifiers.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="404">No entities found.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    [Route(ActionRoutes.DETAILS_MANY)]
    [Consumes(HttpContentType.JSON)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(IEnumerable<AuditEntry>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> DetailsManyPostAsync([FromBody][Required] Guid[] ids, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    {
        var examples = await this.nanoApiClient.Audit
            .DetailsManyAsync(new DetailsManyRequest
            {
                Ids = ids,
                IncludeDepth = includeDepth
            }, cancellationToken);

        return this.Ok(examples);
    }

    /// <summary>
    /// Queries entities matching the specified criteria.
    /// </summary>
    /// <param name="query">The query model containing filters and criteria.</param>
    /// <param name="includeDepth">Optional include depth for related entities.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of entities matching the criteria.</returns>
    /// <response code="200">Entities retrieved successfully.</response>
    /// <response code="400">Invalid query parameters.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="404">No entities found.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    [Route(ActionRoutes.QUERY)]
    [Consumes(HttpContentType.JSON)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(IEnumerable<AuditEntry>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> QueryPostAsync([FromBody][Required] IQuery<ExampleQueryCriteria> query, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    {
        var examples = await this.nanoApiClient.Audit
            .QueryAsync(new QueryRequest<ExampleQueryCriteria>
            {
                Query = query,
                IncludeDepth = includeDepth
            }, cancellationToken);

        return this.Ok(examples);
    }

    /// <summary>
    /// Retrieves the first entity matching the specified criteria.
    /// </summary>
    /// <param name="query">The query model containing filters and criteria.</param>
    /// <param name="includeDepth">Optional include depth for related entities.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The first entity matching the criteria.</returns>
    /// <response code="200">Entity retrieved successfully.</response>
    /// <response code="400">Invalid query parameters.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="404">No entity found.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    [Route(ActionRoutes.QUERY_FIRST)]
    [Consumes(HttpContentType.JSON)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(AuditEntry), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> QueryFirstPostAsync([FromBody][Required] IQuery<ExampleQueryCriteria> query, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    {
        var example = await this.nanoApiClient.Audit
            .QueryFirstAsync(new QueryFirstRequest<ExampleQueryCriteria>
            {
                Query = query,
                IncludeDepth = includeDepth
            }, cancellationToken);

        return this.Ok(example);
    }

    /// <summary>
    /// Gets the total count of entities matching the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria model containing filters.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The number of entities matching the criteria.</returns>
    /// <response code="200">Count retrieved successfully.</response>
    /// <response code="400">Invalid criteria parameters.</response>
    /// <response code="401">Unauthorized access.</response>
    /// <response code="404">No entities found.</response>
    /// <response code="500">Internal server error.</response>
    [HttpPost]
    [Route(ActionRoutes.QUERY_COUNT)]
    [Consumes(HttpContentType.JSON)]
    [Produces(HttpContentType.JSON)]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public virtual async Task<IActionResult> QueryCountPostAsync([FromBody][Required] ExampleQueryCriteria criteria, CancellationToken cancellationToken = default)
    {
        var count = await this.nanoApiClient.Audit
            .QueryCountAsync(new QueryCountRequest<ExampleQueryCriteria>
            {
                Criteria = criteria
            }, cancellationToken);

        return this.Ok(count);
    }
}