# Api.Auth.External.Microsoft

> _Nano API application with transient Microsoft external authentication._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/2nu6awy/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Azure setup](#azure-setup)
* [Configuration](#configuration)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api._Blank)** and adds a derived `AuthController` as well as a simple test controller 
that inherits from the top-level Nano `BaseController`.  

The JWT authentication scheme has been configured, along with the built-in `Microsoft` external login provider. Microsoft needs no `BaseAuthExternalRepository<TFlow>` 
implementation of its own - it's entirely config-driven (`Jwt.ExternalLogins.Microsoft`), and Nano wires up the rest.  

No [Data Identity](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data/README.md#identity) is configured in this lesson, so logins are **transient**: a user 
signs in through Microsoft, gets a JWT with transient claims assigned at login time, and nothing is persisted. See **[Nano Authentication § Persistent vs. transient](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#authentication)**.  

API documentation has been configured to make it easier to explore the available actions in the `AuthController`. Any actions that are not enabled due to omitted configuration 
are automatically excluded. The API documentation is available at: **http://localhost:8080/docs**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#documentation)**.  

The following endpoint from the auth controller is available for testing.  

| Endpoint                                                              | Description                                                                        |
| ---------------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| `http://localhost:8080/api/auth/external/schemes`                     | Retrieves all configured external authentication methods, e.g., Google, Facebook.  |
| `http://localhost:8080/api/auth/login/external/microsoft/transient`   | Signs in a user using external Microsoft authentication, transient.                |

Additionally, the following endpoint is available for testing authorization.  

| Endpoint                                           | Description                                                                                                    |
| -------------------------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/authenticated`  | Returns a simple `200 OK` response, when JWT authorization is successful, and otherwise a `401 Unauthorized`.  |

> 📖 Learn more about **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#authentication)**.

## Azure setup
This lesson talks to real Microsoft infrastructure, so it needs an actual Azure AD (Entra ID) app registration before it can be tested. Run 
[`setup-azure-app-registration.ps1`](setup-azure-app-registration.ps1) once, after `az login`, adjusting `$env:REDIRECT_URI` to match whatever client calls this API - it 
must match exactly what the client sends as `redirect_uri` when exchanging the authorization code. It's a one-time setup script, not meant to be re-run - doing so issues a 
new client secret and can create a duplicate app registration.  

```powershell
$env:APP_DISPLAY_NAME = "nano-api-auth-external-microsoft";
$env:REDIRECT_URI = "http://localhost/auth/callback";
$env:SECRET_DISPLAY_NAME = "nano-lesson-secret";

$env:TENANT_ID = az account show --query "tenantId" -o tsv;
$env:APP_ID = az ad app list --display-name $env:APP_DISPLAY_NAME --query "[0].appId" -o tsv;

az ad app create `
    --display-name $env:APP_DISPLAY_NAME `
    --sign-in-audience AzureADMyOrg `
    --web-redirect-uris $env:REDIRECT_URI;

$env:CLIENT_SECRET = az ad app credential reset `
    --id $env:APP_ID `
    --display-name $env:SECRET_DISPLAY_NAME `
    --years 2 `
    --query "password" -o tsv;
```

The default `User.Read` delegated permission (present on every new app registration) is enough for this lesson - the scopes below (`openid`, `profile`, `email`) don't 
require any Graph API permission at all, since they only control what ends up in the `id_token`, not access to any resource.  

> ⚠️ The client secret is a real credential for your own Azure tenant. Do **not** commit a real value into `appsettings.Development.json` - copy the script's output in 
locally, and keep it out of source control (e.g. via `dotnet user-secrets`, or simply not staging the change).

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
      "RefreshExpiration": "72:00:00",
      "ExternalLogins": {
        "Microsoft": {
          "TenantId": null,
          "ClientId": null,
          "ClientSecret": null,
          "Scopes": [ "openid", "profile", "email" ]
        }
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
      "ExternalLogins": {
        "Microsoft": {
          "TenantId": null,
          "ClientId": null,
          "ClientSecret": null,
          "Scopes": [ "openid", "profile", "email" ]
        }
      }
    }
  }
}
```

Fill in `TenantId`/`ClientId`/`ClientSecret` locally with the values from your own app registration (see **[Azure setup](#azure-setup)** above) before running the solution - 
they're left `null` in this repository on purpose. Use [.NET user secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) (`dotnet user-secrets set 
"App:Authentication:Jwt:ExternalLogins:Microsoft:ClientSecret" "..."`, stored in `secrets.json` outside the repo) rather than editing `appsettings.Development.json` 
directly, so the real values never risk being committed.  

`Scopes` must include `openid` (and should include `profile`/`email`) - Nano reads the login's identity claims (`oid`/`name`/`email`) from the `id_token`, which is only 
returned when `openid` is requested. See **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#authentication)** for the full 
configuration reference.  

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

`Staging`/`Production` don't configure `Jwt.ExternalLogins.Microsoft` in `appsettings.*.json` at all - `TenantId`/`ClientId`/`ClientSecret` are injected as environment 
variables from a Kubernetes secret instead, the same way the JWT keys are, so nothing Microsoft-specific lives in the config files for those environments.

## Kubernetes
For `Staging` and `Production` environments, secrets must be created to securely store the JWT public/private keys and the Microsoft app registration's credentials. Below 
demonstrates how to map both secrets.  

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
        - name: App__Authentication__Jwt__ExternalLogins__Microsoft__TenantId
          valueFrom:
            secretKeyRef:
              name: auth-microsoft-secret
              key: tenant-id
        - name: App__Authentication__Jwt__ExternalLogins__Microsoft__ClientId
          valueFrom:
            secretKeyRef:
              name: auth-microsoft-secret
              key: client-id
        - name: App__Authentication__Jwt__ExternalLogins__Microsoft__ClientSecret
          valueFrom:
            secretKeyRef:
              name: auth-microsoft-secret
              key: client-secret
```

## GitHub Action
The app registration and its client secret are provisioned and rotated by the workflow itself, in a `Setup App Registration` step. Each run adds a new secret alongside 
any existing ones, so pods on the previous secret keep working through the rollout. Older secrets are then pruned down to the newest 3, a 3-deploy grace period.

```yaml
env:
  AUTH_MICROSOFT_REDIRECT_URI: ${{ vars.AUTH_MICROSOFT_REDIRECT_URI }}
```

```yaml
- name: Setup App Registration
  shell: pwsh
  run: |
    $env:APP_DISPLAY_NAME = $env:SERVICE_NAME + "-app";
    $env:SECRET_DISPLAY_NAME = $env:APP_DISPLAY_NAME + "-secret-" + (Get-Date -Format "yyyyMMddHHmmss");
    $env:AUTH_MICROSOFT_CLIENT_ID = az ad app list --display-name $env:APP_DISPLAY_NAME --query "[0].appId" -o tsv;

    if (-not $env:AUTH_MICROSOFT_CLIENT_ID) 
    {
        az ad app create `
            --display-name $env:APP_DISPLAY_NAME `
            --sign-in-audience AzureADMyOrg `
            --web-redirect-uris $env:AUTH_MICROSOFT_REDIRECT_URI;

        $env:AUTH_MICROSOFT_CLIENT_ID = az ad app list --display-name $env:APP_DISPLAY_NAME --query "[0].appId" -o tsv;
    }
    else 
    {
        az ad app update `
            --id $env:AUTH_MICROSOFT_CLIENT_ID `
            --web-redirect-uris $env:AUTH_MICROSOFT_REDIRECT_URI;
    }

    $env:AUTH_MICROSOFT_CLIENT_SECRET = az ad app credential reset `
        --id $env:AUTH_MICROSOFT_CLIENT_ID `
        --append `
        --display-name $env:SECRET_DISPLAY_NAME `
        --years 1 `
        --query "password" -o tsv;

    echo "::add-mask::$env:AUTH_MICROSOFT_CLIENT_SECRET";

    $staleCredentialIds = az ad app credential list --id $env:AUTH_MICROSOFT_CLIENT_ID --query "sort_by(@, &startDateTime)[:-3].keyId" -o tsv;

    foreach ($keyId in ($staleCredentialIds -split "`n" | Where-Object { $_ })) 
    {
        az ad app credential delete `
            --id $env:AUTH_MICROSOFT_CLIENT_ID `
            --key-id $keyId;
    }

    echo "AUTH_MICROSOFT_CLIENT_ID=$env:AUTH_MICROSOFT_CLIENT_ID" >> $env:GITHUB_ENV;
    echo "AUTH_MICROSOFT_CLIENT_SECRET=$env:AUTH_MICROSOFT_CLIENT_SECRET" >> $env:GITHUB_ENV;
```

...and both secrets are created during the Kubernetes deploy step.  
