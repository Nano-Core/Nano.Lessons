# Api.Auth.External.Custom

> _Nano API application with transient custom external authentication._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#summary)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a derived `AuthController` as well as a simple test controller 
that inherits from the top-level Nano `BaseController`.  

The JWT authentication scheme has been configured, and a `BaseAuthExternalRepository<TFlow>` implementation named `ExternalProviderCustomRepository`, with `Custom` as provider-name,
has been added. As a result, additional endpoints from the `AuthController` are now exposed, as shown below.  

The `ExternalProviderCustomRepository` always succeeds and returns static (mocked) data. It serves as a simple example of how to implement a custom external authentication 
provider in Nano.  

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#documentation)**.  

The following endpoint from the auth controller is available for testing.  

| Endpoint                                                          | Description                                                                        |
| ----------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/external/schemes`                 | Retrieves all configured external authentication methods, e.g., Google, Facebook.  |
| `http://localhost:8080/api/auth/login/external/custom/transient`  | Signs in a user using external custom authentication transient                     |

Additionally, the following endpoint is available for testing authorization.  

| Endpoint                                           | Description                                                                                                    |
| -------------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/authenticate`  | Returns a simple `200 OK` response, when JWT authorization is successful, and otherwise a `401 Unauthorized`.  |

> 📖 Learn more about **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#authentication)**.

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
      "Expiration": "01:00:00",
      "RefreshExpiration": "72:00:00"
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
      "Expiration": "24:00:00"
    }
  }
}
```

## Kubernetes
For `Staging` and `Production` environments, a secret must be created to securely store the public and private keys, and optionally the credentials for `RootLogin` if it shoud be 
enabled. Below demonstrates how to map the secret containing the JWT keys.  

```yaml
spec:
  template:
    spec:
      containers:
        env:
        - name: App__Authentication__Jwt__PublicKey
          valueFrom:
            secretKeyRef:
              name: auth-jwt-secret
              key: jwt-public-key
        - name: App__Authentication__Jwt__PrivateKey
          valueFrom:
            secretKeyRef:
              name: auth-jwt-secret
              key: jwt-private-key
```

## GitHub Action
The secrets defined in GitHub must also be mapped for the `Staging` and `Production` environments in the `build-and-deploy.yml` workflow, as shown below.

```yaml
env:
  AUTH_JWT_PUBLIC_KEY: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_AUTH_JWT_PUBLIC_KEY || secrets.STAGING_AUTH_JWT_PUBLIC_KEY }}
  AUTH_JWT_PRIVATE_KEY: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_AUTH_JWT_PRIVATE_KEY || secrets.STAGING_AUTH_JWT_PRIVATE_KEY }}
```

...and created during the Kubernetes deploy step.  
