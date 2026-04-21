# Api.PolicyHeaders.ReferrerPolicy

> _Nano API application with referrer policy._  
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

To observe referrer policy behavior in action, load the `referrer-policy-violation.html` file and inspect how the browser handles (or blocks) the referrer 
in the resulting request.  

| Endpoint                                             | Description                                                                                        |
| ---------------------------------------------------- | -------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/referrer-policy` | Returns a `200 OK` response including the `Referrer-Policy` response header set to `same-origin`.  |

> 📖 Learn more about **[Nano Referrer Policy Header](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#referrer-policy)**.

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "ReferrerPolicy": {
      "ReferrerPolicyHeader": "SameOrigin"
    }
  }
}
```
