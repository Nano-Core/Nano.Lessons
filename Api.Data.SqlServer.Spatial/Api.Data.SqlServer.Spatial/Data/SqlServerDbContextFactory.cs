using Nano.Data;
using Nano.Data.SqlServer;

namespace Api.Data.SqlServer.Spatial.Data;

/// <inheritdoc />
public class SqlServerDbContextFactory : BaseDbContextFactory<SqlServerProvider, SqlServerDbContext>;