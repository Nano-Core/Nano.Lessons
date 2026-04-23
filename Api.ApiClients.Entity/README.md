# Api.ApiClients.Entity

> _Nano API application with api-client._  
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
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)**.  

This lesson focuses on connecting one api application with another and using Nano built-in api-client to work with one application from another.
The inner application has a data provider enabled, in order to showcase the generic api-client integration with data entitty models in Nano. an `BaseApi` implementation has 
also been added to the inner application, allowing the outer application to consume the api-client and use it to get, create, update and deltete entity models in 
the inner application. 

Also root login has been enabled for the application, to try out usingn the root login when connecting one application to another.
Last, health-checks for the api-client has also been configured for the application.

A health check is configured to target the application of the api-client.  
Open **[http://localhost:8080/healthz](http://localhost:8080/healthz)** to view the health-check status in the JSON response.


Endpoints is just a replica of the entity endpoint from the application with the api-client, to demonstrate each entity action


> 📖 Learn more about **[Nano Api Clients](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App#api-clients)**.

## Configuration
Configured the application with a connection to the `NanoApi`.

```json
"App": {
  "Apis": {
    "NanoApiClient": {
      "Host": "localhost",
      "Root": "api",
      "Port": 8181,
      "UseSsl": false,
      "Timeout": "00:00:30",
      "HealthCheck": {
        "UnhealthyStatus": "Unhealthy"
      }
    }
  }
}
```
