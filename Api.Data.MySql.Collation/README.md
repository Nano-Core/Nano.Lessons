# Api.Data.MySql.Collation

> _Nano API application with mysql collation data._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.Data.MySql)**. Entity controllers have been 
simplified to showcase setting mysql default collation; full controllers are unnecessary.  

This example demonstrates setting the `DefaultCollation` in the `Data` section of the configuration. Notice that querying `Example.Name` with 
a case-insensitive collation returns results regardless of letter casing.  

⚠️ Note: Changing this setting affects only new migrations and will not modify existing tables or columns.

> 📖 Learn more about **[Nano.Data.MySql](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data.MySql/README.md#nanodatamysql)**.

## Configuration
The collation is set in `appsettings`.  

```json
"Data": {
  "DefaultCollation": "utf8mb4_general_ci"
}
```