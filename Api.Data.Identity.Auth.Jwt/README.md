# Api.Data.Identity.Auth.Jwt

> _Nano API application with data identity jwt authentication._  
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
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Api.Data.Identity](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.Data.Identity)** and adds a derived `AuthController`.     

Nothing else has changed for this example. The derived `AuthController` enables the identity users in the application to use the three endpoints inherited from 
the `BaseAuthController`.  

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#documentation)**.  

The following endpoint from the auth controller is available for testing:

| Endpoint                                           | Description                                                            |
| -------------------------------------------------- | ---------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/login`             | Authenticates a user and returns an access token (JWT).                |
| `http://localhost:8080/api/auth/login/refresh`     | Refreshes an existing access token.                                    |
| `http://localhost:8080/api/auth/logout`            | Logs out the current user.                                             |

Additionally, the identity controller is also avaialble, and the actions can be used for testing authorization.  

> 📖 Learn more about **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#authentication)**.

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

...and for `Staging` and `Production` environments.

```json
"App": {
  "Authentication": {
    "Jwt": {
        "Issuer": "nano.staging",
        "Audience": "nano.staging"
    }
  }
}
```

```json
"App": {
  "Authentication": {
    "Jwt": {
        "Issuer": "nano.production",
        "Audience": "nano.production"
    }
  }
}
```

## Kubernetes
For `Staging` and `Production` environments, a `auth-jwt-secret.yaml` is also created to securely store the public and private keys, and optionally the credentials for `RootLogin` if it shoud be 
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
The secrets defined in GitHub must also be inbcluded in environmental variables for `Staging` and `Production` environments in the `build-and-deploy.yml` workflow, as shown below.

```yaml
env:
  AUTH_JWT_PUBLIC_KEY: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_AUTH_JWT_PUBLIC_KEY || secrets.STAGING_AUTH_JWT_PUBLIC_KEY }}
  AUTH_JWT_PRIVATE_KEY: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_AUTH_JWT_PRIVATE_KEY || secrets.STAGING_AUTH_JWT_PRIVATE_KEY }}
```

...and created during the Kubernetes deploy step.  
