# Api.HealthChecks

> _Nano API application with health checks._  
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

Open [http://localhost:8080/healthz](http://localhost:8080/healthz) to view the startup health-check report.  
Open [http://localhost:8080/healthz-ui](http://localhost:8080/healthz-ui) to view the startup health-check in the web-based UI.  

A webhook is configured for health-check that will trigger if the application becomes unhealthy.  

| Endpoint                                          | Description                                            |
| ------------------------------------------------- | ------------------------------------------------------ |
| `http://localhost:8080/api/examples/health-check` | Returns a `200 OK` response with health-check status.  |
| `http://localhost:8080/api/examples/webhook`      | Returns a `200 OK` response.                           |

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/Nano.App.Api/README.md#health-checks)**.

## Configuration
```json
"App": {
  "HealthCheck": {
    "EvaluationInterval": 10,
    "FailureNotificationInterval": 60,
    "MaximumHistoryEntriesPerEndpoint": 50,
    "WebHooks": [
      {
        "Name": "Test",
        "Url": "http://localhost:8080/api/examples/webhook",
        "Payload": null
      }
    ]
  }
}
```