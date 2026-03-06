# Api.Versioning

> _Nano API application with versioning._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

The controller is annotated with `[ApiVersion("1.0")]` and `[ApiVersion("2.0")]`, and contains two actions, each mapped to a specific version 
using `[MapToApiVersion("1.0")]` and `[MapToApiVersion("2.0")]`, respectively.  

Observe the response headers `Api-Supported-Version`, containing all versions supported by the application, and the `Api-Version` showing the requested API version
by the client, or the default version if omitted from the request.  

The following endpoint is available for testing.

| Endpoint                                              | Description                                           |
| ----------------------------------------------------- | ----------------------------------------------------- |
| `http://localhost:8080/api/v1.0/examples/versioning`  | Returns a `200 OK` response with the message `v1.0`.  |
| `http://localhost:8080/api/v2.0/examples/versioning`  | Returns a `200 OK` response with the message `v2.0`.  |

> 📖 Learn more about **[Nano Versioning](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#versioning)**.
