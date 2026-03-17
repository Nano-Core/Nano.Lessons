using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.MySql.StoredProcedures.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;