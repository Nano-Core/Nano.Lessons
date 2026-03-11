using Api.Data.MySql.Views.Models;
using Api.Data.MySql.Views.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;

namespace Api.Data.MySql.Views.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IRepository repository)
    : BaseEntityReadOnlyController<Example, ExampleQueryCriteria>(logger, repository);