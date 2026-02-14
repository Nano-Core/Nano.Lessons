# Api.PolicyHeaders.Robots

> _Nano API application with robots options._  
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

| Endpoint                                     | Description                                                                |
| -------------------------------------------- | -------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/nosniff` | Returns a `200 OK` response including the `X-Robots-Tag` response header.  |

> 📖 Learn more about **[Nano Content Type Header](https://github.com/Nano-Core/Nano.Library/Nano.App.Api/README.md#robots)**.

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "Robots": {
      "UseNoIndex": true,
      "UseNoFollow": true,
      "UseNoSnippet": true,
      "UseNoArchive": true,
      "UseNoOdp": true,
      "UseNoTranslate": true,
      "UseNoImageIndex": true
    }
  }
}
```