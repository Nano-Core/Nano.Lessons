# Api.Data.Identity.Auth.External.Custom

> _Nano API application with data identity jwt authentication._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Api.Data.Identity.Auth.Jwt](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.Identity.Auth.Jwt)**.  

An authentication handler has been added, and registerd in the authentication builder in `ConfigureServices(...)` in `program.cs`. JWT is still configured and serves as 
the primary authentication, but now and external direct authentication method is registered as well, and will be exposed in the `/auth/external/schemes` endpoint. The actual
authentication needs to happen separately, and afterwards passing the authenticated data to the `/auth/login/external/direct/transient` endpoint.

The custom external authentication provider will always suceeed, and is just a simple implementation for showcasing.


EXPLAIN THE ABOVE TO CHAT-GPT. I AM NOT SURE I AM DOING THIS CORRECTLY
- schemes ???

ADD POSTMAN

- Write that more advanced use cases can be created with external logins my using an extertnal repository directly with own controller action or use the external auth aggregator.
- Write table of methods for External login Aggregator. 
- Write that if you don't want to implement a IAuthExternalRepository then use Direct methods to handle the actual authentication outside Nano.
- Write explain about IAuthExternalRepository for implementing custom external providers. Derive from BaseAuthExternalRepository and implement a BaseExternal Provider as generic parameter
  - if not deriving from the base class, we don't get the typed members to override.
- Write, correct what we wrote about AddAuthentication(...), consumers shouldn't do that, but still include it if the consumer wants to completely override auth in Nano
- write that if you want to intermidiate things between external authentication and signup or login or add external login, you can use authenticate method from the external auth repository and then
  do what you want and then call direct signup or other methods in the identity and auth repositories.

- Maybe make a table showing which endpoints for auth and identity that is available depending on configuration

- ADD NEW ENDPOINTS TO TABLES (also if we generate some)



  - UPDATE BaseIdentityCOntrlller derived in for example identity example, also jwt




API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. In this example, only the root login action is exposed.  

The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

The following endpoint from the auth controller is available for testing:

| Endpoint                                           | Description                                                            |
| -------------------------------------------------- | ---------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/login`             | Authenticates a user and returns an access token (JWT).                |
| `http://localhost:8080/api/auth/login/refresh`     | Refreshes an existing access token.                                    |
| `http://localhost:8080/api/auth/logout`            | Logs out the current user and clears external authentication cookies.  |

Additionally, the identity controller is also avaialble, and the actions can be used for testing authorization.  

> 📖 Learn more about **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#authentication)**.

## Configuration
Configured the application with the necessary authentication setup, in addition to the identity configuration.  

```json
"App": {
  "Authentication": {
    "Jwt": {
      "Issuer": null,
      "Audience": null,
      "PublicKey": null,
      "PrivateKey": null,
      "Expiration": "01:00:00",
      "RefreshExpiration": "72:00:00"
    }
  }
}
```

...and for `appesettings.Developmnet.json`.

```json
"App": {
  "Authentication": {
    "Jwt": {
      "Issuer": "Development.nano",
      "Audience": "Development.nano",
      "PublicKey": "MIIBCgKCAQEAv7iVNUS5w...",
      "PrivateKey": "MIIEowIBAAKCAQEAv7iV...",
      "Expiration": "24:00:00"
    }
  }
}
```
