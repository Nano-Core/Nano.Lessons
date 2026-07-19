# Api.ApiClients.Audit

> _Nano API application with api-client audit._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.ApiClients](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.ApiClients)**. All the custom methods have been removed and replaced 
with corresponding methods for each audit controller operation in the inner service.

The inner application has a data provider enabled to demonstrate the generic API client integration with Nano entity models. A `NanoApiClient` implementation, derived from 
`BaseApiClient`, has been added to the service application. This lesson showcases how to use the `Audit` sub-group of the `BaseApiClient` to interact with any audit data 
exposed by the inner application.  

The endpoints mirror those of the `AuditController` in the inner service, allowing each entity action to be invoked through the API client for demonstration purposes. In a 
real-world scenario, this structure would typically differ. The outer application would define its own request and response contracts tailored to its domain. However, for 
simplicity and clarity in this example, the responses from the inner service are passed directly through the outer API.

The following endpoint is available for testing.

| Endpoint                                     | Description                                                                                           |
| -------------------------------------------- | ----------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/create`  | Returns a `200 OK` response. Creates an `Example` with nested `ExampleNavigation` which is audited.   |

> 📖 Learn more about **[Nano Api Clients](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App/README.md#api-clients)**.
