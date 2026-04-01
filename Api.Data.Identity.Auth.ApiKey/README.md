# Api.Data.Identity.Auth.ApiKey

> _Nano API application with data identity api-key authentication._  
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

The service has been configured for API key authentication. Nothing else has changed.  

Use the `auth/login/apikey` to authenticate and receive a JWT token, to use in subsequent requests.  

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

The following endpoint from the auth controller is available for testing:

| Endpoint                                           | Description                                                                               |
| -------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/login/apikey`      | Authenticates the user using `X-Api-Key` header value and returns an access token (JWT).  |
| `http://localhost:8080/api/auth/login`             | Authenticates a user and returns an access token (JWT).                                   |
| `http://localhost:8080/api/auth/login/refresh`     | Refreshes an existing access token.                                                       |
| `http://localhost:8080/api/auth/logout`            | Logs out the current user.                                                                |

Additionally, the identity controller is also avaialble, and the actions can be used for testing authorization.  

> 📖 Learn more about **[Nano API Key Authentication](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#authentication)**.

## Configuration
Configured the application with the necessary authentication setup, in addition to the existing identity and jwt configuration.  

```json
"App": {
  "Data": {
    "Identity": {
      "ApiKey": {
        "Secret": "secret"
      }
    }
  }
}
```

## Kubernetes
For `Staging` and `Production` environments, a secret must be created to securely store the apikey secret. Below demonstrates how to map the secret containing the API key secret.  

```yaml
spec:
  template:
    spec:
      containers:
        env:
        - name: Data__Identity__ApiKey
          valueFrom:
            secretKeyRef:
              name: auth-api-key-secret
              key: apikey-secret
```

## GitHub Action
The secrets defined in GitHub must also be mapped for the `Staging` and `Production` environments in the `build-and-deploy.yml` workflow, as shown below.

```yaml
env:
  AUTH_API_KEY_SECRET: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_AUTH_API_KEY_SECRET || secrets.STAGING_AUTH_API_KEY_SECRET }}
```

...and created during the Kubernetes deploy step.  

```yaml
sudo kubectl create secret generic auth-api-key-secret --from-literal=apikey-secret=$env:AUTH_API_KEY_SECRET --save-config --dry-run=client -o yaml | sudo kubectl apply -f -;
if ($LastExitCode -ne 0)
{ 
    throw "error";
};
```
