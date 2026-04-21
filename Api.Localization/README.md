# Api.Localization

> _Nano API application with request localization._  
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

This example shows how to use localized requests in Nano.  

The controller return a response in the following format:

```json
{
    "Name": "Danish",          // The name of the culture language
    "EnglishName": "Danish",   // The english name of the culture language
    "NativeName": "Dansk",     // The native name of the culture language
}
```

| Endpoint                                          | Description                                                      |
| ------------------------------------------------- | ---------------------------------------------------------------- |
| `http://localhost:8080/api/examples/localization` | Returns a `200 OK` response with names of the culture langauge.  |

> 📖 Learn more about **[Nano Localization](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#localization)**.

## Configuration

```json
"App": {
  "Localization": {
    "DefaultCulture": "en-US",
    "SupportedCultures": [
      "da-DK"
    ]
  }
}
```