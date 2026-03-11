using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nano.Data;
using Nano.Data.Abstractions.Config;
using Nano.Eventing.Abstractions;

namespace Console.Data.SqlServer.Data;

/// <inheritdoc />
public class SqlServerDbContext(DbContextOptions contextOptions, IOptionsMonitor<DataOptions> dataOptions, IEventing? eventing = null)
    : BaseDbContext(contextOptions, dataOptions, eventing);