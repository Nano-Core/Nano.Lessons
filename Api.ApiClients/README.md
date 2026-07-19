# Api.ApiClients

> _Nano API application with api-clients._  
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
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api._Blank)**.  

This lesson demonstrates how to connect one API application to another using Nano’s built-in API client, enabling seamless communication between services.  

A `NanoApiClient` implementation, derived from `BaseApiClient`, has been added to the inner service application. It includes several methods that demonstrate different 
features of the Nano API client. These methods are in turn exposed through corresponding endpoints in the `ExamplesController` of the outer API application. In addition, 
the outer application has been configured to include the API client, enabling it to communicate with the inner service application.

A health check is configured to target the application of the api-client.  
Open **[http://localhost:8080/healthz](http://localhost:8080/healthz)** to view the health-check status in the JSON response.

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#health-checks)**.

The following endpoint is available for testing.

| Endpoint                                                       | Description                                                                                                                                               |
| -------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/custom/{id:guid}/{type}`   | Returns a `200 OK` response. The provided route, query, header, and body variables are forwarded to the inner service and returned in the response.       |
| `http://localhost:8080/api/examples/custom/file`               | Returns a `200 OK` response. A file is uploaded via the API client, and the uploaded filename is returned in the response.                                |
| `http://localhost:8080/api/examples/custom/file/body`          | Returns a `200 OK` response. A file and form data are uploaded via the API client, and both the filename and request body are returned in the response.   |
| `http://localhost:8080/api/examples/bad-request-exception`     | Returns a `400 Bad Request` response. A `BadRequestException` is intentionally thrown to demonstrate error handling.                                      |
| `http://localhost:8080/api/examples/problem-details-exception` | Returns a `417 Expectation Failed` response. A `ProblemDetailsException` is thrown to demonstrate structured error handling using Problem Details.        |
| `http://localhost:8080/api/examples/request-tracing`           | Returns a `200 OK` response. The `X-Request-Id` header is extracted from the request and returned in the response for traceability purposes.              |

> 📖 Learn more about **[Nano Api Clients](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App/README.md#api-clients)**.

## Configuration
Configured the application with a connection to the `NanoApiClient`.

```json
"App": {
  "Apis": {
    "NanoApiClient": {
      "Host": "localhost",
      "Root": "api",
      "Port": 8080,
      "UseSsl": false,
      "Timeout": "00:00:30",
      "HealthCheck": {
        "UnhealthyStatus": "Unhealthy"
      }
    }
  }
}
```
