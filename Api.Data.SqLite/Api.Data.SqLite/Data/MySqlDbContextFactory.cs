using Nano.Data;
using Nano.Data.SqLite;

namespace Api.Data.SqLite.Data;

/// <inheritdoc />
public class MySqlDbContextFactory : BaseDbContextFactory<SqLiteProvider, SqLiteDbContext>;