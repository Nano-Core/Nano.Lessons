using Nano.Data;
using Nano.Data.MySql;

namespace Api.ApiClient.Service.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;