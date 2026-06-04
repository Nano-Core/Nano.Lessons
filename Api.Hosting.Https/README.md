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

> 📖 Learn more about **[Nano Hosting HTTPS](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#https)**.

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
A `httproute.yaml` resource has been added to the `.kubernetes` folder.  

| File / Directory     | Type    | Description                                  |
| -------------------- | ------- | -------------------------------------------- |
|  `httproute.yaml`    | `yaml`  | The http route spec for Kubernetes Gateway.  |

## GitHub Actions
Deployment commands have been updated to apply the new Kubernetes `HTTPRoute` template.  

```powershell
Get-Content .kubernetes/{resource-name}.yaml `
    | foreach { [Environment]::ExpandEnvironmentVariables($_) } `
    | Set-Content .kubernetes/{resource-name}.tmp.yaml;

sudo kubectl apply -f .kubernetes/{resource-name}.tmp.yaml;
```
