# Api.PolicyHeaders.ForwardedHeaders

> _Nano API application with forwarded headers enabled._  
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

Invoke the endpoint in the example controller to see the updated scheme, host, and remote IP address. The response also includes the original headers, 
which reflect the internal service values rather than the forwarded ones. The example request includes three `X-Forwarded-*` headers to simulate a reverse proxy scenario.  

| Endpoint                                     | Description                                                              |
| -------------------------------------------- | ------------------------------------------------------------------------ |
| `http://localhost:8080/api/examples/nosniff` | Returns a `200 OK` response with `HttpContext` forwarded header values.  |

> 📖 Learn more about **[Nano Forwarded Headers](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#forwarded-headers)**.

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "ForwardedHeaders": {
      "Headers": "All",
      "RequireHeaderSymmetry": true
    }
  }
}
```
