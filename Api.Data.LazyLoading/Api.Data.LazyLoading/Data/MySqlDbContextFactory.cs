using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.LazyLoading.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;