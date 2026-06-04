using Nano.Data;
using Nano.Data.MySql;

namespace Api.ApiClients.Audit.Service.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;