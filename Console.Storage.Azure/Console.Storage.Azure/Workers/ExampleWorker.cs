using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;
using Nano.App.Console.Workers;
using Nano.Storage.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Console.Storage.Azure.Workers;

/// <summary>
/// Example Worker.
/// </summary>
/// <param name="logger">The <see cref="ILogger"/>.</param>
/// <param name="pathProvider">The <see cref="IPathProvider"/>.</param>
public class ExampleWorker(ILogger<ExampleWorker> logger, IPathProvider pathProvider) : BaseWorker(logger)
{
    /// <summary>
    /// Example On Start.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    public override async Task OnStartAsync(CancellationToken cancellationToken = default)
    {
        System.Console.WriteLine("Example Worker Started...");

        var fileName = Path.GetFileName("test-file.txt");
        var savePath = Path.Combine(pathProvider.Root, fileName);

        await File.WriteAllTextAsync(savePath, "content", Encoding.UTF8, cancellationToken);

        System.Console.WriteLine("Example Worker Completed...");
    }
}