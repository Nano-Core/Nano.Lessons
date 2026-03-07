using Api.Data.MySql.Models;
using Api.Data.MySql.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;

namespace Api.Data.MySql.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExampleCreateablesController(ILogger<ExampleCreateablesController> logger, IRepository repository)
    : BaseEntityCreatableController<ExampleCreatable, ExampleQueryCriteria>(logger, repository);