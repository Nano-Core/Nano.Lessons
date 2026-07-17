# Api.Documentation

> _Nano API application with api documentation._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#gitHub-actions)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This example shows using API documentation for an Nano application. Run the solution and open 
[http://localhost:8080/docs](http://localhost:8080/docs) in your browser to view the API documentation.  

You can experiment with the `HideDefaultVersion` setting. When set to `false`, Swagger displays both the non-versioned route and the versioned route 
for the same example endpoint. When set to `true`, Swagger only displays the non-versioned route corresponding to the application's default version.

| Endpoint                                           | Description          |
| -------------------------------------------------- | -------------------- |
| `http://localhost:8080/api/examples/documentation` | Returns a `200 OK`.  |

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#documentation)**.

## Configuration
```json
"App": {
  "Documentation": {
    "Name": "Application",
    "Description": "This is an example application",
    "TermsOfService": "https://github.com/Nano-Core/Nano.Library/blob/master/LICENSE",
    "Contact": {
      "Name": "Nano Contributors",
      "Email": "email@email.com",
      "Url": "https://github.com/Nano-Core"
    },
    "License": {
      "Name": "MIT",
      "Identifier": "MIT",
      "Url": "https://github.com/Nano-Core/Nano.Library/blob/master/LICENSE"
    },
    "CspNonce": "null,
    "HideDefaultVersion": true
  }
}
```
