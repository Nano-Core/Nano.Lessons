# Api.ApiClients.RootLogIn

> _Nano API application with api-client root authentication._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [Kubernetes](#kubernetes)

## Summary
This application builds on **[Api.ApiClients](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.ApiClients)**. All custom methods have been removed and replaced 
with a new method that triggers the configured root login.

The service is configured with Root Login and JWT authentication enabled, along with a concrete implementation of `BaseAuthController`. When invoking methods through the 
API client, the automatic root login mechanism is triggered.

The following endpoint is available for testing.

| Endpoint                                                     | Description                                                                                                     |
| ------------------------------------------------------------ | --------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/auto-authenticate-root`  | Returns a `200 OK` response. Uses the API client’s automatic root login to obtain and return an access token.   |

> 📖 Learn more about **[Nano Api Clients](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App/README.md#api-clients)**.

## Configuration
Configured the application with a connection to the `NanoApiClient`, including `LogInRoot` credentials for the automatic root login.

```json
"App": {
  "Apis": {
    "NanoApiClient": {
      "Host": "api.apiclients.rootlogin.service",
      "Root": "api",
      "Port": 8181,
      "UseSsl": false,
      "Timeout": "00:00:30",
      "LogInRoot": {
        "Username": null,
        "Password": null
      },
      "HealthCheck": {
        "UnhealthyStatus": "Unhealthy"
      }
    }
  }
}
```

...and `appsettings.Development.json`.

```json
"App": {
  "Apis": {
    "NanoApiClient": {
      "LogInRoot": {
        "Username": "admin@domain.com",
        "Password": "abc12|+d34DadD"
      }
    }
  }
}
```

## Kubernetes
For `Staging` and `Production`, `LogInRoot` is mapped from a secret rather than a config file. See **[Api.Auth.RootLogin](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.Auth.RootLogin)** 
for how that secret (`auth-root-login-secret`) is created; this application only consumes it, it doesn't create it.

```yaml
spec:
  template:
    spec:
      containers:
        env:
        - name: App__Apis__NanoApiClient__LogInRoot__Username
          valueFrom:
            secretKeyRef:
              name: auth-root-login-secret
              key: root-login-username
        - name: App__Apis__NanoApiClient__LogInRoot__Password
          valueFrom:
            secretKeyRef:
              name: auth-root-login-secret
              key: root-login-password
```
