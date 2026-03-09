using Api.Data.Repository.Includes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Api.Data.Repository.Includes.Controllers.Response;

namespace Api.Data.Repository.Includes.Controllers;

/// <summary>
/// Controller with examples.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class ExamplesController(ILogger<ExamplesController> logger, IRepository repository)
    : BaseEntityController(logger, repository)
{
    /// <summary>
    /// Create Action.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpPost]
    [Route("create")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task CreateAsync(CancellationToken cancellationToken = default)
    {
        await this.CreateCustomerAsync(cancellationToken);
    }

    /// <summary>
    /// Include Action.
    /// </summary>
    /// <param name="includeDepth">The include-depth.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("include")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> IncludeAsync([FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    {
        var customer = await this.Repository
            .GetFirstAsync<Customer>(x => true, includeDepth, cancellationToken);

        return this.Ok(customer);
    }

    /// <summary>
    /// Create And Include Action.
    /// </summary>
    /// <param name="includeDepth">The include-depth.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A Cusetomer.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("create-and-include")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> CreateAndIncludeAsync([FromQuery]int? includeDepth, CancellationToken cancellationToken = default)
    {
        var customer = await this.CreateCustomerAsync(cancellationToken);

        customer = await this.Repository
            .GetAsync<Customer>(customer.Id, includeDepth, cancellationToken);

        return this.Ok(customer);
    }

    /// <summary>
    /// Not Include Action.
    /// </summary>
    /// <param name="includeDepth">The include-depth.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A message.</returns>
    /// <response code="200">Success.</response>
    [HttpGet]
    [Route("not-include")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> NotIncludeAsync([FromQuery] int? includeDepth, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        var customer = new CustomerResponse
        {
            Id = Guid.NewGuid(),
            Profile = new CustomerProfileResponse
            {
                Id = Guid.NewGuid(),
                Name = "name"
            },
            Orders = new List<OrderResponse>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Payment = new PaymentResponse
                    {
                        Id = Guid.NewGuid()
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Payment = new PaymentResponse
                    {
                        Id = Guid.NewGuid()
                    }
                }
            }
        };

        return this.Ok(customer);
    }


    private async Task<Customer> CreateCustomerAsync(CancellationToken cancellationToken = default)
    {
        var customer = await this.Repository
            .AddAsync(new Customer
            {
                Profile = new CustomerProfile
                {
                    Name = "name"
                },
                Orders = new List<Order>
                {
                    new()
                    {
                        Payment = new Payment()
                    },
                    new()
                    {
                        Payment = new Payment()
                    }
                }
            }, cancellationToken);

        return customer;
    }
}