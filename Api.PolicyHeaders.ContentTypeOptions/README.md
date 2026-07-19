# Api.PolicyHeaders.ContentTypeOptions

> _Nano API application with content type options._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

To observe content-type sniffing in action, load the `content-type-sniff-violation.html` file and see the browser block execution of the script 
served with an incorrect `.txt` content-type.

| Endpoint                                     | Description                                                                        |
| -------------------------------------------- | ---------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/nosniff` | Returns a `200 OK` response including the Content-Type `nosniff` response header.  |

> 📖 Learn more about **[Nano Content Type Header](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#content-type-options)**.

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "ContentType": {
      "NoSniff": true
    }
  }
}
```
