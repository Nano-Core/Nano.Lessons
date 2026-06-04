using Nano.Data;
using Nano.Data.SqlServer;

namespace Api.Data.SqlServer.Data;

/// <inheritdoc />
public class SqlServerDbContextFactory : BaseDbContextFactory<SqlServerProvider, SqlServerDbContext>;