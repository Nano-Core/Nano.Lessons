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

The `Example` entity implements `IEntitySoftDeletable`, so when an entity is deleted, it is not removed from the database but is marked as deleted 
by setting the `IsDeleted` property.  

The data mapping also includes two triggers for `OnDeleting` and `OnDeleted` to show that they are invoked also when soft-deleting entity models.  

Open the database and notice that the created `Example` entity has a non-zero `IsDeleted` value, indicating it has been soft-deleted.  

> 📖 Learn more about **[Nano Data Soft Delete](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#soft-delete)**.
