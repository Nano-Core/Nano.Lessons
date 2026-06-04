using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Triggers.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;