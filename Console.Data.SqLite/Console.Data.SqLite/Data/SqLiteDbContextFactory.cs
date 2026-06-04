using Nano.Data;
using Nano.Data.SqLite;

namespace Console.Data.SqLite.Data;

/// <inheritdoc />
public class SqLiteDbContextFactory : BaseDbContextFactory<SqLiteProvider, SqLiteDbContext>;