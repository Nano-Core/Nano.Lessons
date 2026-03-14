using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nano.Data;
using Nano.Data.Abstractions.Config;

namespace Api.Data.SqlServer.Spatial.Data;

/// <inheritdoc />
public class SqlServerDbContext(DbContextOptions contextOptions, IOptionsMonitor<DataOptions> dataOptions)
    : BaseDbContext(contextOptions, dataOptions);