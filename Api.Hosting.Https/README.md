# Api.Hosting.Https

> _Nano API application with https._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#gitHub-actions)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This example simply shows configuring a Nano application for HTTPS exposure.  

It adds HTTPS configuration, including a `localhost.pfx` self-signed development certificate, and a simple test controller that inherits 
from the top-level Nano `BaseController`.  

The following endpoints are available for testing:

| Endpoint                                     | Description                            |
| -------------------------------------------- | -------------------------------------- |
| `http://localhost:8080/api/examples/http`    | Redirects to HTTPS.                    |
| `https://localhost:4443/api/examples/https`  | Returns a simple `200 OK` response.    |

> 📖 Learn more about **[Nano Hosting HTTPS](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#https)**.

## Configuration
For `appsettings.json`, nothing has changed - HTTP is still exposed.  
HTTPS and the development certificate are only configured in `appsettings.Development.json`. In live environments, HTTPS is handled by the ingress 
in Kubernetes. Certificates are managed externally, and the service only needs to expose an HTTP port in `service.yaml` for mapping traffic through the ingress, 
which serves HTTPS and forwards it to HTTP.

```json
"App": {
  "Hosting": {
    "http": {
      "UseHttpsRedirection": true
    },
    "Https": {
      "Ports": [
        4443
      ],
      "Certificate": {
        "Path": "/root/.dotnet/https/localhost.pfx",
        "Password": "password"
      },
      "UseHttpsRequired": true
    }
  }
}
```

## Docker-compose
Added the following port and certificate path mapping to `docker-compose.yml`.  

```yaml
services:
  nano.api.hosting.https:
    ports:
      - 4443:4443
    volumes:
      - ../:/root/.dotnet/https
```

## Kubernetes
A `certificate.yaml` and a `ingress.yml` resource has been added to the `.kubernetes` folder.  

| File / Directory     | Type    | Description                            |
| -------------------- | ------- | -------------------------------------- |
|  `ingress.yaml`      | `yaml`  | The ingress spec for Kubernetes.       |
|  `certificate.yaml`  | `yaml`  | The certificate spec for Kuberentes.   |


## GitHub Actions
Additional environment variables have been added to `build-and-deploy.yml` to support the new Kubernetes resources.  

```yaml
env:
  CERTIFICATE_ISSUER: letsencrypt-prod
  CERTIFICATE_ORGANIZATION: ${{ vars.CERTIFICATE_ORGANIZATION }}
  CERTIFICATE_HOST: ${{ github.ref == 'refs/heads/master' && vars.HOST_API_SUBDOMAIN + '.' + vars.PRODUCTION_HOST || vars.HOST_API_SUBDOMAIN + '.' + vars.STAGING_HOST }}
```

Deployment commands have also been updated to apply each of the new Kubernetes templates.  

```powershell
Get-Content .kubernetes/{resource-name}.yaml `
    | foreach { [Environment]::ExpandEnvironmentVariables($_) } `
    | Set-Content .kubernetes/{resource-name}.tmp.yaml;

sudo kubectl apply -f .kubernetes/{resource-name}.tmp.yaml;
```
