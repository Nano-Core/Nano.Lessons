# Api.Data.Triggers

> _Nano API application with data triggers._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**, but any data provider can be used to 
demonstrate repository autosave. Entity controllers have been simplified to showcase triggers; full controllers are unnecessary.   

Triggers for `OnInserting`, `OnInserted`, `OnUpdating`, `OnUpdated`, `OnDeleting`, and `OnDeleted` have been configured in mappings for the `Example` entity model. Whenever 
the `Example` entity is **added** or **updated**, the `Example.UpdatedAt` property is automatically set to `UtcNow`. Additionally, for each trigger execution, an 
`ExampleTrigger` entity is created and stored. This serves as a record demonstrating that the trigger was invoked.  

> 📖 Learn more about **[Nano Data Triggers](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#triggers)**.
