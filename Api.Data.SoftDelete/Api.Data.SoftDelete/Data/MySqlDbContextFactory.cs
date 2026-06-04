using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.SoftDelete.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;