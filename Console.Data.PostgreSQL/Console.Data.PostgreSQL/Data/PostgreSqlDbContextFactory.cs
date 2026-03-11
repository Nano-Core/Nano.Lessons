using Nano.Data;
using Nano.Data.PostgreSQL;

namespace Console.Data.PostgreSQL.Data;

/// <inheritdoc />
public class PostgreSqlDbContextFactory : BaseDbContextFactory<PostgresSqlProvider, PostgreSqlDbContext>;