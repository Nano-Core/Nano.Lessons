# Api.Authorization

> _Nano API application with custom authorization policy._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Auth.RootLogin](https://github.com/Nano-Core/Nano.Lessons/tree/master/Auth.RootLogin)**.  

A custom authorization policy has been configured for the application. The `ServiceCollectionExtensions.AddCustomAuthorizationPolicy(...)` method adds the `CustomPolicy`,
and the `/forbidden` endpoint enforces the policy using a custom `[Authorize(Policy = "CustomPolicy")]` annotation. The policy itself requires the JWT token to contain
a `CustomClaim` claim type.

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. In this example, only the root login action is exposed.  

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

The following endpoint from the auth controller is available for testing.  

| Endpoint                                           | Description                                                                                                    |
| -------------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/login/root`        | Logins with the root credentials from configuration, and returns a simple `200 OK` response with a JWT token.  |

Additionally, the following endpoint is available for testing authorization.  

| Endpoint                                           | Description                                                                                                                              |
| -------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/authenticate`  | Returns a simple `200 OK` response, when JWT authorization is successful.                                                                |
| `http://localhost:8080/api/examples/forbidden`     | Returns a simple `200 OK` response, when JWT authorization is successful with `CustomClaim`, otherwise returns `403 FORBIDDEN` response. |

> 📖 Learn more about **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#authentication)**.
