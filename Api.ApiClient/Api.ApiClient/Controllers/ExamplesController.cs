using Api.ApiClient.Service.Models;
using Api.ApiClient.Service.Models.Api;
using DynamicExpression.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.App.ApiClient.Requests;
using Nano.App.ApiClient.Requests.Models;
using Nano.Common.Consts;
using Nano.Data.Abstractions.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ApiClient.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="nanoApiClient">The <see cref="NanoApiClient"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, NanoApiClient nanoApiClient) : BaseController(logger)
{
    private readonly NanoApiClient nanoApiClient = nanoApiClient ?? throw new ArgumentNullException(nameof(nanoApiClient));


    ///// <summary>
    ///// Custom Action.
    ///// </summary>
    ///// <param name="cancellationToken">The cancellation token.</param>
    ///// <returns>A message.</returns>
    ///// <response code="200">Success.</response>
    //[HttpGet]
    //[Route("custom")]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //public virtual async Task<IActionResult> CustomAsync(CancellationToken cancellationToken = default)
    //{
    //    await this.nanoApiClient.Entity
    //        .IndexAsync<Example>(new IndexRequest(), cancellationToken);

    //    return this.Ok("custom");
    //}

    //#region Read

    ///// <summary>
    ///// Gets all entities matching the specified query.
    ///// </summary>
    ///// <param name="query">The query used to filter entities.</param>
    ///// <param name="includeDepth">Optional include depth for related entities.</param>
    ///// <param name="cancellationToken">The cancellation token.</param>
    ///// <returns>A collection of entities matching the query.</returns>
    ///// <response code="200">Entities retrieved successfully.</response>
    ///// <response code="400">Invalid query parameters.</response>
    ///// <response code="401">Unauthorized access.</response>
    ///// <response code="404">No entities found.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpGet]
    //[Route(ActionRoutes.INDEX)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEnumerable<IEntity>), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> IndexAsync([FromQuery][Required] IQuery query, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    //{
    //    IEnumerable<TEntity> results;

    //    if (includeDepth.HasValue)
    //    {
    //        results = await this.Repository
    //            .GetManyAsync<TEntity>(query, includeDepth.Value, cancellationToken);
    //    }
    //    else
    //    {
    //        results = await this.Repository
    //            .GetManyAsync<TEntity>(query, cancellationToken);
    //    }

    //    return this.Ok(results);
    //}

    ///// <summary>
    ///// Gets a single entity by its identifier.
    ///// </summary>
    ///// <param name="id">The identifier of the entity.</param>
    ///// <param name="includeDepth">Optional include depth for related entities.</param>
    ///// <param name="cancellationToken">The cancellation token.</param>
    ///// <returns>The entity matching the identifier.</returns>
    ///// <response code="200">Entity retrieved successfully.</response>
    ///// <response code="400">Invalid identifier.</response>
    ///// <response code="401">Unauthorized access.</response>
    ///// <response code="404">Entity not found.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpGet]
    //[Route(ActionRoutes.DETAILS)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> DetailsAsync([FromRoute][Required] Guid id, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    //{
    //    TEntity? result;

    //    if (includeDepth.HasValue)
    //    {
    //        result = await this.Repository
    //            .GetAsync<TEntity, Guid>(id, includeDepth.Value, cancellationToken);
    //    }
    //    else
    //    {
    //        result = await this.Repository
    //            .GetAsync<TEntity, Guid>(id, cancellationToken);
    //    }

    //    if (result == null)
    //    {
    //        return this.NotFound();
    //    }

    //    return this.Ok(result);
    //}

    ///// <summary>
    ///// Gets multiple entities by their identifiers.
    ///// </summary>
    ///// <param name="ids">The identifiers of the entities.</param>
    ///// <param name="includeDepth">Optional include depth for related entities.</param>
    ///// <param name="cancellationToken">The cancellation token.</param>
    ///// <returns>The entities matching the identifiers.</returns>
    ///// <response code="200">Entities retrieved successfully.</response>
    ///// <response code="400">Invalid identifiers.</response>
    ///// <response code="401">Unauthorized access.</response>
    ///// <response code="404">No entities found.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.DETAILS_MANY)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEnumerable<IEntity>), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> DetailsManyPostAsync([FromBody][Required] Guid[] ids, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    //{
    //    IEnumerable<TEntity> results;

    //    if (includeDepth.HasValue)
    //    {
    //        results = await this.Repository
    //            .GetManyAsync<TEntity, Guid>(ids, includeDepth.Value, cancellationToken);
    //    }
    //    else
    //    {
    //        results = await this.Repository
    //            .GetManyAsync<TEntity, Guid>(ids, cancellationToken);
    //    }

    //    return this.Ok(results);
    //}

    ///// <summary>
    ///// Queries entities matching the specified criteria.
    ///// </summary>
    ///// <param name="query">The query model containing filters and criteria.</param>
    ///// <param name="includeDepth">Optional include depth for related entities.</param>
    ///// <param name="cancellationToken">The cancellation token.</param>
    ///// <returns>A collection of entities matching the criteria.</returns>
    ///// <response code="200">Entities retrieved successfully.</response>
    ///// <response code="400">Invalid query parameters.</response>
    ///// <response code="401">Unauthorized access.</response>
    ///// <response code="404">No entities found.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.QUERY)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEnumerable<IEntity>), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> QueryPostAsync([FromBody][Required] IQuery<TCriteria> query, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    //{
    //    IEnumerable<TEntity> results;

    //    if (includeDepth.HasValue)
    //    {
    //        results = await this.Repository
    //            .GetManyAsync<TEntity, TCriteria>(query, includeDepth.Value, cancellationToken);
    //    }
    //    else
    //    {
    //        results = await this.Repository
    //            .GetManyAsync<TEntity, TCriteria>(query, cancellationToken);
    //    }

    //    return this.Ok(results);
    //}

    ///// <summary>
    ///// Retrieves the first entity matching the specified criteria.
    ///// </summary>
    ///// <param name="query">The query model containing filters and criteria.</param>
    ///// <param name="includeDepth">Optional include depth for related entities.</param>
    ///// <param name="cancellationToken">The cancellation token.</param>
    ///// <returns>The first entity matching the criteria.</returns>
    ///// <response code="200">Entity retrieved successfully.</response>
    ///// <response code="400">Invalid query parameters.</response>
    ///// <response code="401">Unauthorized access.</response>
    ///// <response code="404">No entity found.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.QUERY_FIRST)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> QueryFirstPostAsync([FromBody][Required] IQuery<TCriteria> query, [FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    //{
    //    TEntity? result;

    //    if (includeDepth.HasValue)
    //    {
    //        result = await this.Repository
    //            .GetFirstAsync<TEntity, TCriteria>(query, includeDepth.Value, cancellationToken);
    //    }
    //    else
    //    {
    //        result = await this.Repository
    //            .GetFirstAsync<TEntity, TCriteria>(query, cancellationToken);
    //    }

    //    if (result == null)
    //    {
    //        return this.NotFound();
    //    }

    //    return this.Ok(result);
    //}

    ///// <summary>
    ///// Gets the total count of entities matching the specified criteria.
    ///// </summary>
    ///// <param name="criteria">The criteria model containing filters.</param>
    ///// <param name="cancellationToken">The cancellation token.</param>
    ///// <returns>The number of entities matching the criteria.</returns>
    ///// <response code="200">Count retrieved successfully.</response>
    ///// <response code="400">Invalid criteria parameters.</response>
    ///// <response code="401">Unauthorized access.</response>
    ///// <response code="404">No entities found.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.QUERY_COUNT)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> QueryCountPostAsync([FromBody][Required] TCriteria criteria, CancellationToken cancellationToken = default)
    //{
    //    var result = await this.Repository
    //        .CountAsync<TEntity, TCriteria>(criteria, cancellationToken);

    //    return this.Ok(result);
    //}

    //#endregion


    //#region Create

    ///// <summary>
    ///// Creates a single model instance.
    ///// </summary>
    ///// <param name="entity">The entity to create.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>The created entity.</returns>
    ///// <response code="201">Entity created.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.CREATE)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.Created)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> CreateAsync([FromBody][Required] TEntity entity, CancellationToken cancellationToken = default)
    //{
    //    var entityCreated = await this.Repository
    //        .AddAsync(entity, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Created(ActionRoutes.CREATE, entityCreated);
    //}

    ///// <summary>
    ///// Creates or edits a single model instance.
    ///// </summary>
    ///// <param name="entity">The entity to create.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>The created or edited entity.</returns>
    ///// <response code="201">Entity created.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.CREATE_OR_EDIT)]
    //[Authorize(Policy = AuthorizationPolicies.ADD_OR_EDIT)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> CreateOrEditAsync([FromBody][Required] TEntity entity, CancellationToken cancellationToken = default)
    //{
    //    var entityAddedOrUpdated = await this.Repository
    //        .AddOrUpdateAsync(entity, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Ok(entityAddedOrUpdated);
    //}

    ///// <summary>
    ///// Creates a single model instance or if it already exist, retrieves it with included navigations.
    ///// </summary>
    ///// <param name="entity">The entity to create.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>The created entity with included navigations.</returns>
    ///// <response code="201">Entity created.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.CREATE_OR_GET)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.Created)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> CreateOrGetAsync([FromBody][Required] TEntity entity, CancellationToken cancellationToken = default)
    //{
    //    var entityCreatedOrGet = await this.Repository
    //        .AddOrGetAsync<TEntity, Guid>(entity, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Created(ActionRoutes.CREATE_OR_GET, entityCreatedOrGet);
    //}

    ///// <summary>
    ///// Creates a single model instance and retrieves it with included navigations.
    ///// </summary>
    ///// <param name="entity">The entity to create.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>The created entity with included navigations.</returns>
    ///// <response code="201">Entity created.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.CREATE_AND_GET)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.Created)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> CreateAndGetAsync([FromBody][Required] TEntity entity, CancellationToken cancellationToken = default)
    //{
    //    var entityCreated = await this.Repository
    //        .AddAndGetAsync<TEntity, Guid>(entity, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Created(ActionRoutes.CREATE_AND_GET, entityCreated);
    //}

    ///// <summary>
    ///// Creates multiple model instances.
    ///// </summary>
    ///// <param name="entities">The entities to create.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="201">Entities created.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.CREATE_MANY)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.Created)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> CreateManyAsync([FromBody][Required] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .AddManyAsync(entities, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Created();
    //}

    ///// <summary>
    ///// Creates multiple model instances in bulk.
    ///// </summary>
    ///// <param name="entities">The entities to create.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Ok.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPost]
    //[Route(ActionRoutes.CREATE_MANY_BULK)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.Created)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> CreateManyBulkAsync([FromBody][Required] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .AddManyBulkAsync(entities, cancellationToken);

    //    return this.Created();
    //}

    //#endregion


    //#region Edit

    ///// <summary>
    ///// Edits a single model instance.
    ///// </summary>
    ///// <param name="entity">The entity to edit.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>The edited entity.</returns>
    ///// <response code="200">Entity updated.</response>
    ///// <response code="404">Entity not found.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPut]
    //[Route(ActionRoutes.EDIT)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> EditAsync([FromBody][Required] TEntity entity, CancellationToken cancellationToken = default)
    //{
    //    var entityEdited = await this.Repository
    //        .UpdateAsync(entity, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Ok(entityEdited);
    //}

    ///// <summary>
    ///// Edits a single model instance and retrieves it with included navigations.
    ///// </summary>
    ///// <param name="entity">The entity to edit.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>The edited entity.</returns>
    ///// <response code="201">Entity updated.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPut]
    //[Route(ActionRoutes.EDIT_GET)]
    //[Consumes(HttpContentType.JSON)]
    //[Produces(HttpContentType.JSON)]
    //[ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> EditAndGetAsync([FromBody][Required] TEntity entity, CancellationToken cancellationToken = default)
    //{
    //    var entityEdited = await this.Repository
    //        .UpdateAndGetAsync<TEntity, Guid>(entity, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Ok(entityEdited);
    //}

    ///// <summary>
    ///// Edits multiple model instances.
    ///// </summary>
    ///// <param name="entities">The entities to edit.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Entities updated.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPut]
    //[Route(ActionRoutes.EDIT_MANY)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> EditManyAsync([FromBody][Required] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .UpdateManyAsync(entities, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Ok();
    //}

    ///// <summary>
    ///// Edits multiple model instances in bulk.
    ///// </summary>
    ///// <param name="entities">The entities to edit.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Entities updated.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPut]
    //[Route(ActionRoutes.EDIT_MANY_BULK)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> EditManyBulkAsync([FromBody][Required] IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .UpdateManyBulkAsync(entities, cancellationToken);

    //    return this.Ok();
    //}

    ///// <summary>
    ///// Edits entities that match the specified criteria.
    ///// </summary>
    ///// <param name="query">The update query containing criteria and property updates.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Entities updated.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPut]
    //[Route(ActionRoutes.EDIT_QUERY)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> EditQueryAsync([FromBody][Required] UpdateQuery<TCriteria> query, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .UpdateManyAsync<TEntity, TCriteria>(query.Criteria, query.PropertyUpdates, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Ok();
    //}

    ///// <summary>
    ///// Edits entities that match the specified criteria in bulk.
    ///// </summary>
    ///// <param name="query">The update query containing criteria and property updates.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Entities updated.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpPut]
    //[Route(ActionRoutes.EDIT_QUERY_BULK)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> EditQueryBulkAsync([FromBody][Required] UpdateQuery<TCriteria> query, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .UpdateManyBulkAsync<TEntity, TCriteria>(query.Criteria, query.PropertyUpdates, cancellationToken);

    //    return this.Ok();
    //}

    //#endregion

    //#region Delete

    ///// <summary>
    ///// Deletes a single entity by its identifier.
    ///// </summary>
    ///// <param name="id">The identifier of the entity to delete.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Entity deleted.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="404">Entity not found.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpDelete]
    //[Route(ActionRoutes.DELETE)]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> DeleteAsync([FromRoute][Required] Guid id, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .DeleteAsync<TEntity, Guid>(id, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Ok();
    //}

    ///// <summary>
    ///// Deletes multiple entities by their identifiers.
    ///// </summary>
    ///// <param name="ids">The identifiers of the entities to delete.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Entities deleted.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="404">Entities not found.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpDelete]
    //[Route(ActionRoutes.DELETE_MANY)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> DeleteManyAsync([FromBody][Required] Guid[] ids, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .DeleteManyAsync<TEntity, Guid>(ids, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Ok();
    //}

    ///// <summary>
    ///// Deletes multiple entities by their identifiers in bulk.
    ///// </summary>
    ///// <param name="ids">The identifiers of the entities to delete.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Entities deleted.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="404">Entities not found.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpDelete]
    //[Route(ActionRoutes.DELETE_MANY_BULK)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.NotFound)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> DeleteManyBulkAsync([FromBody][Required] Guid[] ids, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .DeleteManyBulkAsync<TEntity, Guid>(ids, cancellationToken);

    //    return this.Ok();
    //}

    ///// <summary>
    ///// Deletes entities matching the specified criteria.
    ///// </summary>
    ///// <param name="select">The criteria for selecting entities to delete.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Entities deleted.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpDelete]
    //[Route(ActionRoutes.DELETE_QUERY)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> DeleteQueryAsync([FromBody][Required] TCriteria select, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .DeleteManyAsync<TEntity, TCriteria>(select, cancellationToken);

    //    await this.Repository
    //        .SaveChangesAsync(cancellationToken);

    //    return this.Ok();
    //}

    ///// <summary>
    ///// Bulk deletes entities matching the specified criteria.
    ///// </summary>
    ///// <param name="select">The criteria for selecting entities to delete.</param>
    ///// <param name="cancellationToken">Cancellation token.</param>
    ///// <returns>Void.</returns>
    ///// <response code="200">Entities deleted.</response>
    ///// <response code="400">Bad request.</response>
    ///// <response code="401">Unauthorized.</response>
    ///// <response code="500">Internal server error.</response>
    //[HttpDelete]
    //[Route(ActionRoutes.DELETE_QUERY_BULK)]
    //[Consumes(HttpContentType.JSON)]
    //[ProducesResponseType((int)HttpStatusCode.OK)]
    //[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    //public virtual async Task<IActionResult> DeleteQueryBulkAsync([FromBody][Required] TCriteria select, CancellationToken cancellationToken = default)
    //{
    //    await this.Repository
    //        .DeleteManyBulkAsync<TEntity, TCriteria>(select, cancellationToken);

    //    return this.Ok();
    //}

    //#endregion
}