using Nano.App.ApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;
using Api.ApiClients.Service.Models.Api.Requests;
using Api.ApiClients.Service.Models.Api.Responses;

namespace Api.ApiClients.Service.Models.Api;

/// <summary>
/// Nano Api Client.
/// </summary>
public class NanoApiClient(ApiClient apiClient) : BaseApiClient(apiClient)
{
    /// <summary>
    /// Custom Async.
    /// </summary>
    /// <param name="request">The <see cref="CustomRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="CustomResponse"/>.</returns>
    public Task<CustomResponse?> CustomAsync(CustomRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        return this.InvokeAsync<CustomRequest, CustomResponse>(request, cancellationToken);
    }

    /// <summary>
    /// Custom File Async.
    /// </summary>
    /// <param name="request">The <see cref="CustomFileRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="CustomFileResponse"/>.</returns>
    public Task<CustomFileResponse?> CustomFileAsync(CustomFileRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        return this.InvokeAsync<CustomFileRequest, CustomFileResponse>(request, cancellationToken);
    }

    /// <summary>
    /// Custom File Body Async.
    /// </summary>
    /// <param name="request">The <see cref="CustomFileBodyRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="CustomFileBodyResponse"/>.</returns>
    public Task<CustomFileBodyResponse?> CustomFileBodyAsync(CustomFileBodyRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        return this.InvokeAsync<CustomFileBodyRequest, CustomFileBodyResponse>(request, cancellationToken);
    }

    /// <summary>
    /// Bad Request Exception Async.
    /// </summary>
    /// <param name="request">The <see cref="BadRequestExceptionRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Nothing.</returns>
    public Task BadRequestExceptionAsync(BadRequestExceptionRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Problem Details Exception Async.
    /// </summary>
    /// <param name="request">The <see cref="ProblemDetailsExceptionRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>Nothing.</returns>
    public Task ProblemDetailsExceptionAsync(ProblemDetailsExceptionRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        return this.InvokeAsync(request, cancellationToken);
    }

    /// <summary>
    /// Request Tracing Async.
    /// </summary>
    /// <param name="request">The <see cref="RequestTracingRequest"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="RequestTracingResponse"/>.</returns>
    public Task<RequestTracingResponse?> RequestTracingAsync(RequestTracingRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        return this.InvokeAsync<RequestTracingRequest, RequestTracingResponse>(request, cancellationToken);
    }
}