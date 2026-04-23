using System;
using Api.ApiClients.Entity.Service.Models.Api;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;

namespace Api.ApiClients.Controllers;

// BUG: Testing
// - forwarding headers
// - Root login(authenticate through api-client)
// - Request tracing
// - FromFormBody attribute
// - file upload

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="nanoApiClient">The <see cref="NanoApiClient"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, NanoApiClient nanoApiClient) : BaseController(logger)
{
    private readonly NanoApiClient nanoApiClient = nanoApiClient ?? throw new ArgumentNullException(nameof(nanoApiClient));
}