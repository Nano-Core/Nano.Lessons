using Api.Data.Triggers.Models;
using Api.Data.Triggers.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;

namespace Api.Data.Triggers.Controllers;

/// <summary>
/// Controller with example triggers.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExampleTriggersController(ILogger<ExampleTriggersController> logger, IRepository repository)
    : BaseEntityController<ExampleTrigger, ExampleTriggerQueryCriteria>(logger, repository);