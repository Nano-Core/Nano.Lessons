# Api.Hosting.MultipartLimits

> Nano API application with upload limits._  
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

This example demonstrates upload limits configured for a Nano application.   

Added multipart limits for file uploads, setting max upload size to 1 MB.  

The following endpoint is available for testing.

| Endpoint                                          | Description                                              |
| ------------------------------------------------- | -------------------------------------------------------- |
| `http://localhost:8080/api/examples/upload-file`  | Upload a file, if larger than 1 MB it will be rejected.  |

> 📖 Learn more about **[Nano MultiPart Limits](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Apimultipart-limits)**.

## Configuration
Added the following configuration to `appsettings.json`.

```json
Added
  "App": {
    "Hosting": {
      "MultipartLimits": {
        "MaxUploadBytes": 1048576,
        "KeepAliveTimeout": 30
      }
}
```
