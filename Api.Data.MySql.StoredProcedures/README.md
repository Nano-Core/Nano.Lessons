# Api.Data.MySql.StoredProcedures

> _Nano API application with mysql views data._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**. Entity controllers have been 
simplified to showcase setting mysql views; full controllers are unnecessary.  

An `ExampleView` entity model (deriving from `BaseEntityView`) has been added, along with a mapping class based on `BaseEntityViewMapping`. The corresponding database view has 
been manually added in an empty migration.

```csharp
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

migrationBuilder
    .Sql(ExampleViewDefinition.SQL);
```

Also, an `ExampleViewsController` (deriving from `BaseEntityQueryableController`) has been added, exposing query actions for the view.

> 📖 Learn more about **[Nano.Data.MySql](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.MySql)**.
