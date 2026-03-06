# Api.StartupTasks

> _Nano API application with startup tasks._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

After approximately 20 seconds, the startup task will complete, and the health check endpoint will report a status of `Healthy`.  

The following endpoint is available for testing.  

| Endpoint                                            | Description                            |
| --------------------------------------------------- | -------------------------------------- |
| `http://localhost:8080/api/examples/startup-tasks`  | Returns a simple `200 OK` response.    |

> 📖 Learn more about **[Nano Startup Tasks](https://github.com/Nano-Core/tree/master/Nano.Library/Nano.App#startup-tasks)**.

## Configuration
There is no configuration required for startup tasks themselves.  
The health-check configuration has just been added to observe that the `self` health-check reports `Healthy`.

```json
  "App": {
    "HealthCheck": {
      "EvaluationInterval": 2,
      "FailureNotificationInterval": 5,
      "MaximumHistoryEntriesPerEndpoint": 5000
    }
  }
````
