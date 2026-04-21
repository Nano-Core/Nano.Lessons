# Api.Data.Repository.Includes

> _Nano API application with data repository include annotations._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**, but any data provider can be used to 
demonstrate repository include annotations. Entity controllers have been simplified to showcase include annotation; full controllers are unnecessary.  

The endpoints can be invoked with the `includeDepth` query parameter to override the default configured depth. This makes it easy to experiment with different values 
and observe how the returned object graph changes as Nano resolves deeper levels of includes.  

All the navigations in the object graph is annotated with `IncludeAttribute`, except for `Customer.Profile`. Because of this, it is not exposed during 
response serialization, even that the instance is already loaded in the data context. Only properties explicitly marked for inclusion are serialized in the response. You 
can read more about this behavior in the [Response Serialization](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#response-serialization) section.  

Observe how includes and nested includes appear in the response after the entities have been created and subsequently retrieved 
using `IRepository.GetAsync<TEntity>(...)`. This demonstrates how Nano automatically resolves and serializes the configured include graph according to the effective depth.  

Another endpoint returns plain objects that do not implement `IEntity`, so the full object graph is always serialized.  

The following endpoint is available for testing.  

| Endpoint                                                | Description                                                                                                                                                                                                                                           |
| ------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/create`             | Returns a simple `200 OK` response. Creates a Customer entity with related navigations.                                                                                                                                                               |
| `http://localhost:8080/api/examples/include`            | Returns a simple `200 OK` response with `Customer` entity and nested included navigation properties. Requires a `Cusetomer` entity to be created first.                                                                                               |
| `http://localhost:8080/api/examples/create-and-include` | Returns a simple `200 OK` response. Creates a `Customer` entity and nested included navigation properties, and returns it. ⚠️ If request `includeDepth` is lower than configuration, serialization still exposes the depth using the confoguration.   |
| `http://localhost:8080/api/examples/not-include`        | Returns a simple `200 OK` response with `CustomerResponse`, that is not `IEntity`, and all properties are serialzied and exposed.                                                                                                                     |

> 📖 Learn more about **[Nano Include Annotation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#include-annotation)**.

## Configuration
Configured the application with the necessary data setup.  

```json
"Data": {
  "Repository": {
    "QueryIncludeDepth": 3
  }
}
```
