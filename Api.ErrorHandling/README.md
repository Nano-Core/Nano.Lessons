# Api.ErrorHandling

> _Nano API application showing error handling._  
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
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This example demonstrates how Nano API error handling processes exceptions and other errors to produce the appropriate HTTP responses.  

The following endpoint is available for testing:

| Endpoint                                                               | Description                                                                                                   |
| ---------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/exception`                         | Returns a `500 Internal Server Error` response. `Detail` exposed because `ExposeErrors` is set to `true`.     |
| `http://localhost:8080/api/examples/exception-aggregate`               | Returns a `500 Internal Server Error` response. `Detail` exposed because `ExposeErrors` is set to `true`.     |
| `http://localhost:8080/api/examples/exception-virus-scan`              | Returns a `400 Bad Request` response. `Detail` always exposed.                                                |
| `http://localhost:8080/api/examples/exception-unauthorized`            | Returns a `401 Unauthorized` response. `Detail` always exposed.                                               |
| `http://localhost:8080/api/examples/exception-permission-denied`       | Returns a `403 Forbidden` response. Usually no `Detail`, but always exposed.                                  |
| `http://localhost:8080/api/examples/exception-identity`                | Returns a `400 Bad Request` response. `Detail` always exposed.                                                |
| `http://localhost:8080/api/examples/exception-bad-request`             | Returns a `400 Bad Request` response. `Detail` always exposed.                                                |
| `http://localhost:8080/api/examples/exception-bad-request-coded`       | Returns a `400 Bad Request` response. `Detail` always exposed. `IsCoded` property added and set to `true`.    |
| `http://localhost:8080/api/examples/exception-bad-request-translated`  | Returns a `400 Bad Request` response. `Detail` always exposed. `IsTranslated` property added set to `true`.   |
| `http://localhost:8080/api/examples/exception-task-canceled`           | Returns a `408 Request Timeout` response. `Detail` always exposed.                                            |
| `http://localhost:8080/api/examples/exception-operation-canceled`      | Returns a `408 Request Timeout` response. `Detail` always exposed.                                            |
| `http://localhost:8080/api/examples/exception-problem-details`         | Varies depending on the `ProblemDetails`.                                                                     |
| `http://localhost:8080/api/examples/validation-error`                  | Returns a `400 Bad Request` response.  `Detail` always exposed.                                               |

Alternatively, toggle the `ExposeErrors` to `false`, and observe that messages from `500 Internal Server Errors` no longer will be exposed.  

> 📖 Learn more about **[Nano Error Handling](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#error-handling)**.

## Configuration
```json
"App": {
  "ErrorHandling": {
    "ExposeErrors": true
  }
}
```
