# Api.Data.Audit

> _Nano API application with data audit logging._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**, but any data provider can be used to 
demonstrate audit logging. Entity controllers have been simplified to showcase autosave; full controllers are unnecessary. Also an `AuditControlller` derived from 
`BaseAuditControlller` has been added.  

The `Example` entity implements `IEntityAuditable`. The entity model is also mapped with a `OnUpdating(...)` trigger to prove that changes to the entity model will be reflected
in audit properties. Last, the entity model also implements the `IEntitySoftDeletable` so when deleted the `AuditEntry.State` will be `SoftDeleted`.  

The `AuditController`, which derives from the base `BaseAuditController` in Nano, exposes read-only endpoints for the `AuditEntry` entity. When retrieving or querying 
audit entries, the related `AuditEntryProperties` are automatically included, ensuring that all relevant details are available without additional queries.  

Notice, that when you set the `X-Request-Id` header, the value is automatically recorded in the audit entry. Also the `CreatedBy` is set, and in this case `Anonymous` because
we are invoking the endpoint with an unauthenticated user.  

Also, API documentation has been configured, in order to easier see which audit endpoints are available. It can be accessed 
here: **[http://localhost:8080/docs](http://localhost:8080/docs)**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

> 📖 Learn more about **[Nano Data Audit](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#audit)**.
