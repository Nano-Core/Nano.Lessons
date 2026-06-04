using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.MultipartJson.Controllers.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Annotations;
using Nano.App.Api.Controllers;
using Newtonsoft.Json;

namespace Api.MultipartJson.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger) : BaseController(logger)
{
    /// <summary>
    /// Multipart Json Action.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="body">The json body</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpPost]
    [Route("multipart-json")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> MultipartJsonAsync(IFormFile file, [Required][FromFormBody]JsonBody body, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        Console.WriteLine(file.FileName);
        Console.WriteLine(JsonConvert.SerializeObject(body));

        return this.Ok("multipart-json");
    }
}