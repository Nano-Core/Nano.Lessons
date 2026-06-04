# Api.Logging.Log4Net

> _Nano API application with Log4Net logging._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This application demonstrates logging with Log4Net for a API application. Also note the `LogLevelOverrides` configuration, 
where logs under the `Microsoft` namespace are set to `Warning`, which suppresses several informational messages during application startup.  

The following endpoint is available for testing:

| Endpoint                                                | Description                                                                                                        |
| ------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------ |
| `http://localhost:8080/api/examples/logging`            | Returns a simple `200 OK` response. Won't  log the `.LogDebug(...)` due to configuration `LogLevel=Information`.   |
| `http://localhost:8080/api/examples/logging-exception`  | Returns a simple `500 Internal Server Error` response. The exception will be logged.                               |

> 📖 Learn more about **[Nano.Logging.Log4Net](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Logging.Log4Net/README.md#nanologginglog4net)**.

## Registration
The following logging has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(services =>
{
    services
        .AddNanoLogging<Log4NetProvider>();
})
...
```

## Configuration
Configured the application with the necessary logging setup.  

```json
"Logging": {
  "LogLevel": "Information",
  "LogLevelOverrides": [
    {
      "Namespace": "Microsoft",
      "LogLevel": "Warning"
    }
  ]
}
```
