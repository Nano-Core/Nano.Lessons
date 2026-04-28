# Api.PolicyHeaders.XssProtection

> _Nano API application with xxs protection._  
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

Run the endpoint to inspect the `X-XSS-Protection` header in the response. Then load the provided HTML page to observe that the `alert` is blocked by the browser.  

Note that `X-XSS-Protection` is deprecated and ignored by modern browsers, including:  
* Chrome  
* Edge (Chromium)  
* Firefox  

> ⚠️ This header is considered a legacy defense-in-depth mechanism and has been largely replaced by `Content-Security-Policy`.

The following endpoint is available for testing.  

| Endpoint                                 | Description                                                                    |
| ---------------------------------------- | ------------------------------------------------------------------------------ |
| `http://localhost:8080/api/examples/xss` | Returns a `200 OK` response including the `X-XSS-Protection` response header.  |

> 📖 Learn more about **[Nano Xxs Protection Header](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#xxs-protection)**.

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "XssProtection": {
      "XssProtectionPolicyHeader": "FilterEnabledBlockMode"
    }
  }
}
```