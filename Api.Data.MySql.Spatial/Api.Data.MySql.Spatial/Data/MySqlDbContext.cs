using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nano.Data;
using Nano.Data.Abstractions.Config;

namespace Api.Data.MySql.Spatial.Data;

/// <inheritdoc />
public class MySqlDbContext(DbContextOptions contextOptions, IOptionsMonitor<DataOptions> dataOptions)
    : BaseDbContext(contextOptions, dataOptions);