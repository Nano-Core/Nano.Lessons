using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nano.Data;
using Nano.Data.Abstractions.Config;

namespace Api.Data.PostgreSQL.Spatial.Data;

/// <inheritdoc />
public class PostgreSqlDbContext(DbContextOptions contextOptions, IOptionsMonitor<DataOptions> dataOptions)
    : BaseDbContext(contextOptions, dataOptions);