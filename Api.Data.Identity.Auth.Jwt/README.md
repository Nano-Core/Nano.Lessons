# Api.Data.Identity.Auth.Jwt

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
This application builds on **[Api.Data.Identity](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.Identity)** and adds a derived `AuthController`.     

Nothing else has changed for this example. The derived `AuthController` enables the identity users in the application to use the three endpoints inherited from 
the `BaseAuthController`.  

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. In this example, only the root login action is exposed.  

The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

The following endpoint from the auth controller is available for testing:

| Endpoint                                           | Description                                                            |
| -------------------------------------------------- | ---------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/login`             | Authenticates a user and returns an access token (JWT).                |
| `http://localhost:8080/api/auth/login/refresh`     | Refreshes an existing access token.                                    |
| `http://localhost:8080/api/auth/logout`            | Logs out the current user.                                             |

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

```yaml
sudo kubectl create secret generic auth-jwt-secret --from-literal=jwt-public-key=$env:AUTH_JWT_PUBLIC_KEY --from-literal=jwt-private-key=$env:AUTH_JWT_PRIVATE_KEY --save-config --dry-run=client -o yaml | sudo kubectl apply -f -;
if ($LastExitCode -ne 0)
{ 
    throw "error";
};
```

