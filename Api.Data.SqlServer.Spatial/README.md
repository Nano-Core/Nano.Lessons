# Api.Data.SqlServer.Spatial

> _Nano API application with sql server spatial data._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Migrations](#migrations)

## Summary
This application builds on **[Api.Data.SqlServer](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.SqlServer)**. Entity controllers have been simplified to 
showcase spatial types; full controllers are unnecessary.  

The `Example` entity now includes a `Point` property from `NetTopologySuite`. A query criterion has been added to check whether points are within a 10,000 meter distance. The 
entity mappings for this spatial property have also been configured. Otherwise, no other changes were made.  

> ⚠️ Be aware, SQL Server does not create spatial indexes automatically; they must be added manually in a migration.

```csharp
migrationBuilder
    .Sql(@"CREATE SPATIAL INDEX IX_Example_Point
           ON Example(Point)
           USING GEOGRAPHY_GRID");
```

> 📖 Learn more about **[Nano.Data.SqlServer](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.SqlServer/README.md#nanodatamysql)**.
