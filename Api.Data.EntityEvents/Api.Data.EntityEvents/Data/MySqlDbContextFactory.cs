using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.EntityEvents.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;