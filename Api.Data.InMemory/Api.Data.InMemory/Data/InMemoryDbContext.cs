using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nano.Data;
using Nano.Data.Abstractions.Config;
using Nano.Eventing.Abstractions;

namespace Api.Data.InMemory.Data;

/// <inheritdoc />
public class InMemoryDbContext(DbContextOptions contextOptions, IOptionsMonitor<DataOptions> dataOptions)
    : BaseDbContext(contextOptions, dataOptions);