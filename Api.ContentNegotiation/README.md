# Api.ContentNegotiation

> _Nano API application with content negotiation._  
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

The following endpoint is available for testing:

| Endpoint                                                  | Description                                                                       |
| --------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/content-negotiation`  | Returns a simple `200 OK` response, no matter if `Accept` header is set or not.   |

> 📖 Learn more about **[Nano Content Negotiation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#content-negotiation)**.
