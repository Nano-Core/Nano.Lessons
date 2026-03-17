# Api.Data.MySql.StoredProcedures

> _Nano API application with mysql stored procedure data._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**. Entity controllers have been 
simplified to showcase mysql stored procedures; full controllers are unnecessary.  

This example defines a stored procedure, and creates it during a migration.  

```csharp
migrationBuilder
    .Sql(ExampleStoredProcedureDefinition.SQL);
```

The stored procedure is executed using Nano’s `IRepository.ExecuteAsync(...)` via this application's extension method `GetExampleResult`. The method simply wraps the 
repository call to provide a clear, strongly typed invocation point for use by the controller.  

The following endpoint is available for testing:

| Endpoint                                               | Description                                                                                |
| ------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `http://localhost:8080/api/examples/stored-procedure`  | Returns a simple `200 OK` response with the result of the stored procedure as response.    |

> 📖 Learn more about **[Nano.Data.MySql](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.MySql)**.
