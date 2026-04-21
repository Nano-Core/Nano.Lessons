# Api.Data.InMemory

> _Nano API application with in-memory data._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a test controller that inherits from 
the Nano `BaseEntityControllerr<TEntity, TCriteria>`. The available entity endpoints are inherited, and no additional endpoints has been added.  

This example demonstrates how various parts of Nano data work together. All data configuration and registration have been completed, and classes have been implemented 
for the data parts, including [Data Models](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-models), [Data Mappings](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-mappings), 
and the [Data Context](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-context). As the in-memory data provider doesn't use migrations there is no need 
to implement the `BaseDbContextFactory`.  

Additionally, the example shows how Nano [Data Repository](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#repositories) works along with the corresponding 
entity controllers. For more information on controllers and how they are connected with entity models, see [Nano Entity Controllers](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#controllers).

Also, API documentation has been configured, in order to easier see which endpoints are available. It can be accessed 
here: **[http://localhost:8080/docs](http://localhost:8080/docs)**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

Additionally, controllers have been implemented to demonstrate controllers for creatable, updatable, creatable-and-updatable, and deletable entities. When viewing 
the API documentation, observe how the available endpoints differ depending on the capabilities supported by each controller.  

> 📖 Learn more about **[Nano.Data.InMemory](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.InMemory)**.

## Registration
The following data provider has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(services =>
{
    services
        .AddNanoData<InMemoryProvider, InMemoryDbContext>();
})
...
```

## Configuration
Configured the application with the necessary data setup.  

```json
"Data": {
  "BatchSize": 25,
  "BulkBatchSize": 500,
  "BulkBatchDelay": 1000,
  "QueryRetryCount": 0,
  "StartupAction": "None",
  "UseLazyLoading": false,
  "UseSensitiveDataLogging": false,
  "QuerySplittingBehavior": "SingleQuery",
  "DefaultCollation": null,
  "ConnectionString": "nanoDb",
  "Repository": {
    "UseAutoSave": false,
    "QueryIncludeDepth": 4
  },
  "Identity": null,
  "ConnectionPool": null,
  "HealthCheck": null
}
```
