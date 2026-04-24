using Api.Data.Audit.Models;
using Api.Data.Audit.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;

namespace Api.Data.Audit.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExampleNoAuditsController(ILogger<ExampleNoAuditsController> logger, IRepository repository)
    : BaseEntityController<ExampleNoAudit, ExampleQueryCriteria>(logger, repository);