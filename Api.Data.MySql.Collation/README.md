# Api.Data.MySql.Collation

> _Nano API application with mysql collation data._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**. Entity controllers have been 
simplified to showcase setting mysql default collation; full controllers are unnecessary.  

This example shows setting the `DefaultCollation` collation in the `Data` section of the configuration.  

> 📖 Learn more about **[Nano.Data.MySql](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.MySql)**.

## Configuration
The collation is set in `appsettings`.  

```json
"Data": {
  "DefaultCollation": "utf8mb4_bin"
}
```