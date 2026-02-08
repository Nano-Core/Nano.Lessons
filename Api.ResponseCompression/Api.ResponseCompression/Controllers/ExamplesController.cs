using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Common.Consts;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ResponseCompression.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
public class ExamplesController(ILogger logger) : BaseController(logger)
{
    /// <summary>
    /// Http Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>250 KB content.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("compressed")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CompressedAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        var block = new string('A', 1024);
        var payload = string.Concat(Enumerable.Repeat(block, 1024));

        return this.Content(payload, HttpContentType.TEXT);
    }
}