# Api.Session

> _Nano API application with session enabled._  
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

| Endpoint                                           | Description                                               |
| -------------------------------------------------- | --------------------------------------------------------- |
| `http://localhost:8080/api/examples/set-session`   | Sets a session variable and returns a `200 OK`.           |
| `http://localhost:8080/api/examples/get-session`   | Gets the session variable if set and returns a `200 OK`.  |
| `http://localhost:8080/api/examples/clear-session` | Clear the session and returns a `200 OK`.                 |

> 📖 Learn more about **[Nano Session](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#session)**.

## Configuration
```json
"App": {
  "Session": {
    "Timeout": "00:20:00"
  }
}
```