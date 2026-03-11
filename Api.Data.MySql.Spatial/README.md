# Api.Data.MySql.Spatial

> _Nano API application with mysql data._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**.  

This example demonstrates how various parts of Nano data work together. All data configuration and registration have been completed, and classes have been implemented 
for the data parts, including [Data Models](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-models), [Data Mappings](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-mappings), 
and the [Data Context](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-context).  

Additionally, the example shows how Nano [Data Repository](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#repositories) works along with the corresponding 
entity controllers. For more information on controllers and how they are connected with entity models, see [Nano Entity Controllers](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#controllers).

A data health check is configured to target the database.  
Open the health-check UI here to view the database health status: **[http://localhost:8080/healthz-ui](http://localhost:8080/healthz-ui)**.  

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#health-checks)**.

Also, API documentation has been configured, in order to easier see which endpoints are available. It can be accessed 
here: **[http://localhost:8080/docs](http://localhost:8080/docs)**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

Additionally, controllers have been implemented to demonstrate controllers for creatable, updatable, creatable-and-updatable, and deletable entities. When viewing 
the API documentation, observe how the available endpoints differ depending on the capabilities supported by each controller.  

> 📖 Learn more about **[Nano Data MySql](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.MySql)**.
