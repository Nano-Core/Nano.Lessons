using Nano.Data;
using Nano.Data.PostgreSQL;

namespace Api.Data.PostgreSQL.Spatial.Data;

/// <inheritdoc />
public class PostgreSqlDbContextFactory : BaseDbContextFactory<PostgresSqlProvider, PostgreSqlDbContext>;