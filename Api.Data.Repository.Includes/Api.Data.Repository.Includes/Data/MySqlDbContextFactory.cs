using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Repository.Includes.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;