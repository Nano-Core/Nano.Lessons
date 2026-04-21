# Api.PolicyHeaders.Hsts

> _Nano API application with strict-transport-security (HSTS)._  
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
This application builds on **[Api.Hosting.Https](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Hosting.Https)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

The service is configured to run over HTTPS, since HSTS requires a secure connection to be tested effectively.  
To observe HSTS enforcement in action, load the `hsts-violation.html` file and see how the browser blocks non-secure requests.

| Endpoint                                  | Description                                                                             |
| ----------------------------------------- | --------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/hsts` | Returns a `200 OK` response including the `Strict-Transform-Security` response header.  |

> 📖 Learn more about **[Nano Strict Transport Security (HSTS)](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#strict-transport-security-hsts)**.

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "Hsts": {
      "MaxAge": "00:01:00",
      "UsePreload": false,
      "IncludeSubdomains": true
    }
  }
}
```
