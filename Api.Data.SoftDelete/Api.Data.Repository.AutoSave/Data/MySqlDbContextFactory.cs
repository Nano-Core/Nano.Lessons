using Nano.Data;
using Nano.Data.MySql;

namespace Api.Data.Repository.AutoSave.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<MySqlProvider, MySqlDbContext>;