using Nano.Data;
using Nano.Data.MySql;

namespace Api.ApiClients.Entity.Service.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;