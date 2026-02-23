# Api.ResponseCache

> _Nano API application with response cache._  
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

| Endpoint                                               | Description                                                                                                   |
| -------------------------------------------------------| ------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/response-cache`    | Returns a `200 OK` response cached. Header: `Cache-Control=public, max-age=1200`                              |
| `http://localhost:8080/api/examples/no-response-cache` | Returns a `200 OK` response with no cache using Header: `[ResponseCache]`. `Cache-Control=no-store,no-cache`  |

> 📖 Learn more about **[Nano Response Cache](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#response-cache)**.

## Configuration
```json
"App": {
  "ResponseCache": {
    "MaxSize": 1024,
    "MaxBodySize": 102400,
    "MaxAge": "00:20:00"
  }
}
```
