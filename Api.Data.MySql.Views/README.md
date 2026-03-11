# Api.Data.MySql.Views

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

The `Example` entity has been refactored to inherit from `BaseEntityIdentity` and is now mapped as a view using `BaseEntityViewMapping`. Also the entity controller
has been changed to inherit from `BaseEntityReadOnlyController<,>` instaed. Naturally, models mapped as views are always _read-only_. 

The SQL view itself must be manually created and added to a migration.  

> ⚠️ Be aware, SQL Server does not create spatial indexes automatically; they must be added manually in a migration.

```csharp
migrationBuilder
    .Sql(@"CREATE OR REPLACE VIEW ExampleView AS
           SELECT
               Id,
               CreatedAt,
    Name       -- from Example
FROM
    Example;
");
```



> 📖 Learn more about **[Nano.Data.MySql](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.MySql)**.
