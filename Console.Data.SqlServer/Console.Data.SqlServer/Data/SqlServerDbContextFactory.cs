using Nano.Data;
using Nano.Data.SqlServer;

namespace Console.Data.SqlServer.Data;

/// <inheritdoc />
public class SqlServerDbContextFactory : BaseDbContextFactory<SqlServerProvider, SqlServerDbContext>;