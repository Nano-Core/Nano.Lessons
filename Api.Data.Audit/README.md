# Api.Data.Repository.AutoSave

> _Nano API application with data repository autosave disabled._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**, but any data provider can be used to 
demonstrate repository autosave.  

In this application, autosave has been disabled. When the endpoint is invoked, Nano attempts to persist the entity to the database. However, the `IRepository` does 
not commit the changes because autosave is disabled and SaveChanges is not invoked manually within the controller action. As a result, the changes are not written 
to the database. If you switch the configuration to enable autosave, you will see that Nano then saves the changes.  

The following endpoint is available for testing.  

| Endpoint                                       | Description                                                                                        |
| ---------------------------------------------- | -------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/no-save`   | Returns a simple `200 OK` response, while trying to add a new `Example`, changes are never saved.  |

> 📖 Learn more about **[Nano Data Repository Autosave](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#autosave)**.

## Configuration
Configured the application with the necessary data setup.  

```json
"Data": {
  "Repository": {
    "UseAutoSave": false
  }
}
```
