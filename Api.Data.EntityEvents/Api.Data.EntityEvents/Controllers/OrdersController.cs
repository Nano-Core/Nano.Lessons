using Api.Data.EntityEvents.Models;
using Api.Data.EntityEvents.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;

namespace Api.Data.EntityEvents.Controllers;

/// <summary>
/// Controller with Orders.
/// </summary>
/// <param name="logger">The <see cref="ILogger{T}"/>.</param>
/// <param name="repository">The <see cref="IRepository"/>.</param>
public class OrdersController(ILogger<OrdersController> logger, IRepository repository)
    : BaseEntityController<Order, DefaultQueryCriteria>(logger, repository);