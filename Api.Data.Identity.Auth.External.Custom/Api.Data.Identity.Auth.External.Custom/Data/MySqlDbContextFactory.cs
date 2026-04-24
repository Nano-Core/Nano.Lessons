using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Identity.Auth.External.Custom.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;