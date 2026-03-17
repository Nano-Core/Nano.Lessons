using Api.Data.MySql.StoredProcedures.Models;

namespace Api.Data.MySql.StoredProcedures.Data.StoredProcedures;

internal static class ExampleStoredProcedureDefinition
{
    internal static string ExampleCreateOrIncrement => nameof(ExampleStoredProcedureDefinition.ExampleCreateOrIncrement);

    internal const string SQL = $@"
        DROP PROCEDURE IF EXISTS {nameof(ExampleStoredProcedureDefinition.ExampleCreateOrIncrement)};
        
        CREATE PROCEDURE {nameof(ExampleStoredProcedureDefinition.ExampleCreateOrIncrement)} (
            IN p_name VARCHAR(255)
        )
        BEGIN
            DECLARE v_id CHAR(36);
            SELECT {nameof(Example.Id)} INTO v_id FROM {nameof(Example)} WHERE {nameof(Example.Name)} = p_name LIMIT 1;

            IF v_id IS NOT NULL THEN
                UPDATE {nameof(Example)} SET {nameof(Example.Counter)} = {nameof(Example.Counter)} + 1 WHERE {nameof(Example.Id)} = v_id;
            ELSE
                SET v_id = UUID();
                INSERT INTO {nameof(Example)} ({nameof(Example.Id)}, {nameof(Example.Name)}, {nameof(Example.Counter)}) VALUES (v_id, p_name, 1);
            END IF;

            SELECT {nameof(Example.Id)}, {nameof(Example.Name)}, {nameof(Example.Counter)} FROM {nameof(Example)} WHERE {nameof(Example.Id)} = v_id;
        END";
}