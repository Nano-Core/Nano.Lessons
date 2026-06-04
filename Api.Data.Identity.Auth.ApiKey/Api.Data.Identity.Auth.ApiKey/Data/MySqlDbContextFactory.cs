using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Identity.Auth.ApiKey.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;