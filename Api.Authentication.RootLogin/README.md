# Api.Authentication.RootLogin

> _Nano API application with root-login authentication._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#summary)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a derived `AuthController` as well as a simple test controller 
that inherits from the top-level Nano `BaseController`.  

Simply invoke the root login endpoint and use the returned JWT token in the `Authorization` header to authenticate when calling the example controller endpoint.  

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. In this example, only the root login action is exposed.  

The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

The following endpoint is available for testing:

| Endpoint                                           | Description                                                                                                    |
| -------------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/login/root`        | Logins with the root credentials from configuration, and returns a simple `200 OK` response with a JWT token   |
| `http://localhost:8080/api/examples/authenticate`  | Returns a simple `200 OK` response, when JWT authorization is successful, and otherwise a `401 Unauthorized`   |

> 📖 Learn more about **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#authentication)**.

## Configuration
Configured the application with the necessary authentication setup. 

```json
"App": {
  "Authentication": {
    "Jwt": {
      "Issuer": null,
      "Audience": null,
      "PublicKey": null,
      "PrivateKey": null,
      "Expiration": "00:60:00",
      "RefreshExpiration": "72:00:00",
      "RootLogin": {
        "Username": null,
        "Password": null
      }
    }
  }
}
```

...and `appsettings.Development.json`.  

```json
"App": {
  "Authentication": {
    "Jwt": {
      "Issuer": "Development.nano",
      "Audience": "Development.nano",
      "PublicKey": "MIIBCgKCAQEAv7iVNUS5w...",
      "PrivateKey": "MIIEowIBAAKCAQEAv7iV...",
      "Expiration": "24:00:00",
      "RootLogin": {
        "Username": "admin@domain.com",
        "Password": "abc12|+d34DadD"
      }
    }
  }
}
```
