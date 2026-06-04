# Api.PolicyHeaders.Cors

> _Nano API application with cors._  
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

To test CORS behavior, open the provided HTML pages and observe how the browser enforces different CORS restrictions and blocks unauthorized requests.  

Also try out the endpoint, and observe how CORS returns the allowed hosts, headers, and methods.  

| Endpoint                                  | Description                                                       |
| ----------------------------------------- | ----------------------------------------------------------------- |
| `http://localhost:8080/api/examples/cors` | Returns a `200 OK` response including the CORS response headers.  |

> 📖 Learn more about **[Nano Cors](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#cors)**.

## Configuration
```json 
"Cors": {
  "AllowedOrigins": [
    "http://localhost:8080"
  ],
  "AllowedHeaders": [
    "Content-Type"
  ],
  "AllowedMethods": [
    "GET",
    "POST",
    "OPTIONS"
  ],
  "AllowCredentials": true,
  "Origin": {
    "EmbedderPolicy": "UnsafeNone",
    "OpenerPolicy": "SameOriginAllowPopups",
    "ResourcePolicy": "SameOrigin"
  }
}
```
