using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions.Models;
using Nano.Data.Mappings;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Data.MySql.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger) : BaseController(logger)
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

        return this.Ok("http");
    }
}

/// <summary>
/// Example.
/// </summary>
public class Example : DefaultEntity
{
    // Properties
}

/// <summary>
/// Example Mapping.
/// </summary>
public class ExampleMapping : DefaultEntityMapping<Example>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Example> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        base.Configure(builder);

        // Mappings
    }
}
