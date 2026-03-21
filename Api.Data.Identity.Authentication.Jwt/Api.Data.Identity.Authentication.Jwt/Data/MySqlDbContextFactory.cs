using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Identity.Authentication.Jwt.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;