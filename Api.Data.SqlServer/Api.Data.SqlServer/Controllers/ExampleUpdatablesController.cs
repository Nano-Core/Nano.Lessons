using Api.Data.SqlServer.Models;
using Api.Data.SqlServer.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;

namespace Api.Data.SqlServer.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExampleUpdatablesController(ILogger<ExampleUpdatablesController> logger, IRepository repository)
    : BaseEntityUpdatableController<ExampleUpdatable, ExampleQueryCriteria>(logger, repository);