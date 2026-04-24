using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Identity.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;