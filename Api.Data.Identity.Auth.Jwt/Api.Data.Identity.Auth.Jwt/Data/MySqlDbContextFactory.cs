using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Identity.Auth.Jwt.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;