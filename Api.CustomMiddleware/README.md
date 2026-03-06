# Api.CustomMiddleware

> _Nano API application with http._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This example illustrates how custom middleware can be registered within a Nano application.  

The following endpoint is available for testing:

| Endpoint                                                | Description                                                  |
| ------------------------------------------------------- | ------------------------------------------------------------ |
| `http://localhost:8080/api/examples/custom-middleware`  | Returns a simple `200 OK` response, with the custom header.  |

> 📖 Learn more about **[Nano Custom Middleware](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#custom-middleware)**.

## Registration
The application register custom middleware that adds a header `CustomMiddleware` to all response with the value `awesome`, as shown below.  

```csharp
...
.Build(builder =>
{
    builder
        .Use((context, next) =>
        {
            context.Response.Headers["CustomMiddleware"] = "awesome";

            return next();
        });
})
...
```
