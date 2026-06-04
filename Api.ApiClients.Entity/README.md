# Api.ApiClients.Entity

> _Nano API application with api-client entity models._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.ApiClients](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.ApiClients)**. All the custom methods have been removed and replaced 
with corresponding methods for each entity controller operation in the inner service.

The inner application has a data provider enabled to demonstrate the generic API client integration with Nano entity models. A `NanoApiClient` implementation, derived from 
`BaseApiClient`, has been added to the service application. This lesson showcases how to use the `Entity` sub-group of the `BaseApiClient` to interact with any entity model 
exposed by the inner application.

The endpoints mirror those of the entity controller in the inner service, allowing each entity action to be invoked through the API client for demonstration purposes. In a 
real-world scenario, this structure would typically differ. The outer application would define its own request and response contracts tailored to its domain. However, for 
simplicity and clarity in this example, the responses from the inner service are passed directly through the outer API.

> 📖 Learn more about **[Nano Api Clients](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App/README.md#api-clients)**.
