using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.CustomConfigSection.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nano.App.Api.Controllers;

namespace Api.CustomConfigSection.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="customOptions">The <see cref="CustomOptions"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IOptionsMonitor<CustomOptions> customOptions) : BaseController(logger)
{
    private readonly IOptionsMonitor<CustomOptions> customOptions = customOptions ?? throw new ArgumentNullException(nameof(customOptions));

    /// <summary>
    /// Custom Config Section Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("custom-config-section")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CustomConfigSectionAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok($"Custom Config Section Value: '{this.customOptions.CurrentValue.Value}'");
    }
}