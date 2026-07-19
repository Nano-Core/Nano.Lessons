# Api.Data.Identity.Auth.External.Custom

> _Nano API application with data identity external custom authentication._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Data.Identity.Auth.Jwt](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.Data.Identity.Auth.Jwt)**.  

The JWT authentication scheme remains configured, and a `BaseAuthExternalRepository<TFlow>` implementation named `ExternalProviderCustomRepository`, with `Custom` as provider-name,
has been added. As a result, additional endpoints from the `AuthController` are now exposed, as shown below.  

The `ExternalProviderCustomRepository` always succeeds and returns static (mocked) data. It serves as a simple example of how to implement a custom external authentication 
provider in Nano.  

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#documentation)**.  

The following endpoint from the auth controller is available for testing:

| Endpoint                                                | Description                                                                        |
| ------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/external/schemes`       | Retrieves all configured external authentication methods, e.g., Google, Facebook.  |
| `http://localhost:8080/api/auth/login`                  | Authenticates a user and returns an access token (JWT).                            |
| `http://localhost:8080/api/auth/login/external/custom`  | Signs in a user using external custom authentication                               |
| `http://localhost:8080/api/auth/login/refresh`          | Refreshes an existing access token.                                                |
| `http://localhost:8080/api/auth/logout`                 | Logs out the current user.                                                         |

The following new endpoints related to the custom authentication provider from the identity controller is shown below.

| Endpoint                                                              | Description                                                |
| --------------------------------------------------------------------- | ---------------------------------------------------------- |
| `http://localhost:8080/api/users/signup/external/custom`              | Signs up a user using external custom authentication       |
| `http://localhost:8080/api/users/{id}/external-logins`                | Retrieves all external authentication methods of a user.   |
| `http://localhost:8080/api/users/{id}/external-logins/add/custom`     | Adds a `Custom` external login to a user account.          |
| `http://localhost:8080/api/users/{id}/external-logins/remove/custom`  | Removes an `Custom` login from a user account.             |

> 📖 Learn more about **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#authentication)**.

