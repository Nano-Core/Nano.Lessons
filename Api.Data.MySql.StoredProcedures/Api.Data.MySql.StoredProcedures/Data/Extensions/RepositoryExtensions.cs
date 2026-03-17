using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Data.MySql.StoredProcedures.Data.StoredProcedures;
using Api.Data.MySql.StoredProcedures.Models;
using Nano.Data.Abstractions;

namespace Api.Data.MySql.StoredProcedures.Data.Extensions;

internal static class RepositoryExtensions
{
    internal static async Task<ExampleResult?> GetExampleResult(this IRepository repository, string name, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(repository);
        ArgumentNullException.ThrowIfNull(name);

        var dict = new Dictionary<string, object?>
        {
            { "p_name", name }
        };

        var result = await repository
            .ExecuteProcedureAsync<ExampleResult>(ExampleStoredProcedureDefinition.ExampleCreateOrIncrement, dict, cancellationToken);

        return result;
    }
}