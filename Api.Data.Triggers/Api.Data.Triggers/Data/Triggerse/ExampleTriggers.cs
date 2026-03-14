using System;
using Api.Data.Triggers.Models;
using EntityFrameworkCore.Triggers;

namespace Api.Data.Triggers.Data.Triggerse;

internal static class ExampleTriggers
{
    internal static Action<IInsertingEntry<Example>> Inserting = x =>
    {
        x.Entity.UpdatedAt = DateTimeOffset.UtcNow;

        x.Context
            .Add(new ExampleTrigger
            {
                ExampleId = x.Entity.Id,
                Trigger = "OnInserting"
            });
    };

    internal static Action<IInsertedEntry<Example>> Inserted = x =>
    {
        x.Context
            .Add(new ExampleTrigger
            {
                ExampleId = x.Entity.Id,
                Trigger = "OnInserted"
            });
    };

    internal static Action<IUpdatingEntry<Example>> Updating = x =>
    {
        x.Entity.UpdatedAt = DateTimeOffset.UtcNow;

        x.Context
            .Add(new ExampleTrigger
            {
                ExampleId = x.Entity.Id,
                Trigger = "OnUpdating"
            });
    };

    internal static Action<IUpdatedEntry<Example>> Updated = x =>
    {
        x.Context
            .Add(new ExampleTrigger
            {
                ExampleId = x.Entity.Id,
                Trigger = "OnUpdated"
            });
    };

    internal static Action<IDeletingEntry<Example>> Deleting = x =>
    {
        x.Context
            .Add(new ExampleTrigger
            {
                ExampleId = x.Entity.Id,
                Trigger = "OnDeleting"
            });
    };

    internal static Action<IDeletedEntry<Example>> Deleted = x =>
    {
        x.Context
            .Add(new ExampleTrigger
            {
                ExampleId = x.Entity.Id,
                Trigger = "OnDeleted"
            });
    };
}