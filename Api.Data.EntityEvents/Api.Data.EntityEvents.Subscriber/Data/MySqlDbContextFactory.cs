using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.EntityEvents.Subscriber.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;