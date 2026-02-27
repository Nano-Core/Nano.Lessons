using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Common.Consts;
using Nano.Storage.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Nano.App.Api.Extensions;

namespace Api.Storage.Azure.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
/// <param name="pathProvider">The <see cref="IPathProvider"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IPathProvider pathProvider) : BaseController(logger)
{
    /// <summary>
    /// Storage Azure Action.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="cancellationToken">The token used when request is cancelled.</param>
    /// <returns>A message.</returns>
    /// <response code="200">OK.</response>
    [HttpPost]
    [Route("storage-azure")]
    [Consumes(HttpContentType.FORM)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> StorageAzureAsync([Required]IFormFile file, CancellationToken cancellationToken = default)
    {
        var fileName = Path.GetFileName(file.FileName);
        var savePath = Path.Combine(pathProvider.Root, fileName);

        await file
            .SaveFileAsync(savePath, cancellationToken);

        return this.Ok("storage-azure");
    }
}