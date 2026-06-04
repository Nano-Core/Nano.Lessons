using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;
using Api.Data.MySql.Mappings.Models;
using Api.Data.MySql.Mappings.Models.Criterias;

namespace Api.Data.MySql.Mappings.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExampleJsonsController(ILogger<ExampleJsonsController> logger, IRepository repository)
    : BaseEntityController<ExampleJson, ExampleQueryCriteria>(logger, repository);