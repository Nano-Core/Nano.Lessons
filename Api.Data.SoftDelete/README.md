# Api.Data.SoftDelete

> _Nano API application with data soft delete._  
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
demonstrate repository autosave. Entity controllers have been simplified to showcase autosave; full controllers are unnecessary.   



TEST WHAT IEntitySoftDeleted do. Maybe we should not have setting but just enable soft delete for entities implementing the interface IEntitySoftDeleted?
- TEST WHAT IEntitySoftDeleted do, and if it's possible to do soft-delete on only some interfaces, maybe it shouldn't be a configuration, just enabled when entities have the interface.



> 📖 Learn more about **[Nano Data Soft Delete](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#soft-delete)**.

## Configuration
```json
"Data": {
  "UseSoftDeletetion": true
}
```
