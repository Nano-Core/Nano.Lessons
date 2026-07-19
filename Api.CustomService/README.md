# Api.CustomService

> _Nano API application with custom scoped service._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This example demonstrates how a custom service implementation can be registered and used within a Nano application.  

The following endpoint is available for testing.  

| Endpoint                                             | Description                                                                      |
| ---------------------------------------------------- | -------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/custom-servuce`  | Returns a simple `200 OK` response, with a message from the `IExampleServuce`    |

> 📖 Learn more about **[Nano Custom Services](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App/README.md#custom-services)**.

## Registration
A custom service, `IExampleService` has been added and implemented. In `program.cs` the service is registered using `ConfigureService(...)` method as shown below

```csharp
...
.ConfigureServices(services =>
{
    services
        .AddScoped<IExampleService, ExampleService>();
})
...
```
