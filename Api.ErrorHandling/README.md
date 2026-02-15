# Api.ErrorHandling

> _Nano API application with error handling._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Rememmber to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Hosting.Http](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Hosting.Http)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

| Endpoint                                   | Description                                                     |
| ------------------------------------------ | --------------------------------------------------------------- |
| `http://localhost:8080/api/examples/error` | Returns a `500 ERROR` response with the error message exposed.  |

> 📖 Learn more about **[Nano Error Handling](https://github.com/Nano-Core/Nano.Library/Nano.App.Api/README.md#error-handling)**.

## Configuration
```json
"App": {
  "ErrorHandling": {
    "ExposErrors": true
  }
}
```
