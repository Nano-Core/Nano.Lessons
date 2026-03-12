using Api.Data.MySql.Mappings.Models;

namespace Api.Data.MySql.Mappings.Data.Views;

internal static class ExampleViewDefinition
{
    internal const string SQL = $@"
        CREATE OR REPLACE VIEW {nameof(ExampleView)} AS
        SELECT
            {nameof(Example.Id)},
            {nameof(Example.CreatedAt)},
            {nameof(Example.Name)},
            CHAR_LENGTH({nameof(Example.Name)}) AS {nameof(ExampleView.NameLength)}
        FROM {nameof(Example)};";
}