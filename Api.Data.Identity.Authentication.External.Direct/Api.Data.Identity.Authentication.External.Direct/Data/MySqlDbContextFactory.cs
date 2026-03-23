using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Identity.Authentication.External.Direct.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;