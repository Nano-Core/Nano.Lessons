using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Audit.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;