# Api.Auth.RootLogin

> _Nano API application with root login authentication._  
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
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api._Blank)** and adds a derived `AuthController` as well as a simple test controller 
that inherits from the top-level Nano `BaseController`.  

The JWT authentication scheme has been configured. Simply invoke the root login endpoint and use the returned JWT token in the `Authorization` header to authenticate when calling 
the example controller endpoint.  

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#documentation)**.  

The following endpoint from the auth controller is available for testing.  

| Endpoint                                           | Description                                                                                                    |
| -------------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/login/root`        | Logins with the root credentials from configuration, and returns a simple `200 OK` response with a JWT token.  |

Additionally, the following endpoint is available for testing authorization.  

| Endpoint                                           | Description                                                                                                    |
| -------------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/authenticated`  | Returns a simple `200 OK` response, when JWT authorization is successful, and otherwise a `401 Unauthorized`.  |

> 📖 Learn more about **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#authentication)**.

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
      "Expiration": "24:00:00",
      "RootLogin": {
        "Username": "admin@domain.com",
        "Password": "abc12|+d34DadD"
      }
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
For `Staging` and `Production` environments, a secret must be created to securely store the public and private keys. Below demonstrates how to map the secret containing the JWT keys.  

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

`RootLogin` is enabled in `Staging`/`Production` too, via a second, separate secret,
`auth-root-login-secret`, storing the credentials rather than the config file. This isn't a
subordinate part of the JWT key secret above; it has its own name and its own file
(`auth-root-login-secret.yaml`), created and applied the same way:

```yaml
apiVersion: v1
kind: Secret
metadata:
  name: auth-root-login-secret
  namespace: %KUBERNETES_NAMESPACE%
type: Opaque
stringData:
  root-login-username: %AUTH_ROOT_LOGIN_USERNAME%
  root-login-password: %AUTH_ROOT_LOGIN_PASSWORD%
```

...and mapped into `deployment.yaml` alongside the JWT keys:

```yaml
spec:
  template:
    spec:
      containers:
        env:
        - name: App__Authentication__Jwt__RootLogin__Username
          valueFrom:
            secretKeyRef:
              name: auth-root-login-secret
              key: root-login-username
        - name: App__Authentication__Jwt__RootLogin__Password
          valueFrom:
            secretKeyRef:
              name: auth-root-login-secret
              key: root-login-password
```

> ⚠️ `RootLogin` is a statically-configured, transient login, and the credential itself grants a
> full `administrator` identity to whoever holds it, same as any other root login. Keep it out of
> source control the same way as the JWT private key: real values only via this secret, never in
> a checked-in `appsettings.json`.

## GitHub Action
The secrets defined in GitHub must also be mapped for the `Staging` and `Production` environments in the `build-and-deploy.yml` workflow, as shown below.

```yaml
env:
  AUTH_JWT_PUBLIC_KEY: ${{ github.ref == 'refs/heads/main' && secrets.PRODUCTION_AUTH_JWT_PUBLIC_KEY || secrets.STAGING_AUTH_JWT_PUBLIC_KEY }}
  AUTH_JWT_PRIVATE_KEY: ${{ github.ref == 'refs/heads/main' && secrets.PRODUCTION_AUTH_JWT_PRIVATE_KEY || secrets.STAGING_AUTH_JWT_PRIVATE_KEY }}
  AUTH_ROOT_LOGIN_USERNAME: ${{ github.ref == 'refs/heads/main' && secrets.PRODUCTION_AUTH_ROOT_LOGIN_USERNAME || secrets.STAGING_AUTH_ROOT_LOGIN_USERNAME }}
  AUTH_ROOT_LOGIN_PASSWORD: ${{ github.ref == 'refs/heads/main' && secrets.PRODUCTION_AUTH_ROOT_LOGIN_PASSWORD || secrets.STAGING_AUTH_ROOT_LOGIN_PASSWORD }}
```

...and created during the Kubernetes deploy step, applying both `auth-jwt-secret.yaml` and
`auth-root-login-secret.yaml` before `deployment.yaml`.  
