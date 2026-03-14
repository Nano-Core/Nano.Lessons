using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nano.Data;
using Nano.Data.Abstractions.Config;

namespace Console.Data.SqlServer.Data;

/// <inheritdoc />
public class SqlServerDbContext(DbContextOptions contextOptions, IOptionsMonitor<DataOptions> dataOptions)
    : BaseDbContext(contextOptions, dataOptions);