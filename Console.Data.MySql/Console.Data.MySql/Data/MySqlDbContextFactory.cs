using Nano.Data;
using Nano.Data.MySql;

namespace Console.Data.MySql.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;