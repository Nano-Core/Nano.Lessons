using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;

namespace Api.ApiClients.Audit.Service.Controllers;

/// <inheritdoc />
public class AuditController(ILogger<BaseAuditController> logger, IRepository repository) 
    : BaseAuditController(logger, repository);