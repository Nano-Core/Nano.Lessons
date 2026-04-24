using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Common.Consts;

namespace Api.Hosting.MultipartLimits.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger) : BaseController(logger)
{
    /// <summary>
    /// Upload File.
    /// Max size: 1 MB.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="cancellationToken">The token used when request is cancelled.</param>
    /// <returns>A message.</returns>
    /// <response code="200">OK.</response>
    [HttpPost]
    [Route("upload-file")]
    [Consumes(HttpContentType.FORM)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> UploadFileAsync([Required]IFormFile file, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return this.Ok($"File: '{file.FileName}' Uploadeed. Size: {file.Length} bytes.");
    }
}