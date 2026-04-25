# Api.TimeZone

> _Nano API application with request timezone._  
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

The example demonstrates using request time zone in a Nano application.  

Both the GET and POST endpoints in the controller return a response in the following format:

```json
{
    "RequestDateTimeLocal": "2026-02-08T14:23:45+03:00",   // The date-time sent by the client in the request
    "ServerReceivedUtc": "2026-02-08T11:23:45Z",           // The UTC date-time when the server received the request
    "ResponseDateTimeLocal": "2026-02-08T14:23:45+03:00",  // The date-time returned to the client, adjusted to the requested timezone
    "DateTimeInfoNow": "2026-02-10T11:40:37+03:00",        // The current local date-time on the server
    "DateTimeInfoUtcNow": "2026-02-10T08:40:37.7265135Z"   // The current UTC date-time on the server
}
```

The following endpoint is available for testing.

| Endpoint                                                    | Description                                                                                                            |
| ----------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/timezone` (GET,POST)    | Returns a `200 OK` response with various `DateTimeOffset` properties illustrating the date-time timezone conversions.  |

> 📖 Learn more about **[Nano TimeZone](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#timezone)**.

## Configuration
```json
"App": {
  "TimeZone": {
    "DefaultTimeZone": "UTC"
  }
}
```
