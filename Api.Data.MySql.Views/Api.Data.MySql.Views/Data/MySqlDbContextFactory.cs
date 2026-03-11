using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.MySql.Views.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;