# Api.Hosting.Https

> _Nano API application with https._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#gitHub-actions)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This example simply shows configuring a Nano application for HTTPS exposure.  

It adds HTTPS configuration, including a `localhost.pfx` self-signed development certificate, and a simple test controller that inherits 
from the top-level Nano `BaseController`.  

The following endpoints are available for testing:

| Endpoint                                     | Description                            |
| -------------------------------------------- | -------------------------------------- |
| `http://localhost:8080/api/examples/http`    | Redirects to HTTPS.                    |
| `https://localhost:4443/api/examples/https`  | Returns a simple `200 OK` response.    |

> 📖 Learn more about **[Nano Hosting HTTPS](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#https)**.

## Configuration
For `appsettings.json`, nothing has changed - HTTP is still exposed.  
HTTPS and the development certificate are only configured in `appsettings.Development.json`. In live environments, HTTPS is handled by the ingress 
in Kubernetes. Certificates are managed externally, and the service only needs to expose an HTTP port in `service.yaml` for mapping traffic through the ingress, 
which serves HTTPS and forwards it to HTTP.

The `appsettings.json` has this configuration.

```json
"App": {
  "Hosting": {
    "Root": "api",
    "Http": {
      "Ports": [
        8080
      ],
      "UseHttpsRedirection": false
    }
  }
}
```

and the `appsettings.Development.json` this.

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
A `httproute-80.yaml` and `httproute-443.yaml` resource has been added.

```yaml
apiVersion: gateway.networking.k8s.io/v1
kind: HTTPRoute
metadata:
  name: %SERVICE_NAME%-route-80
  namespace: %KUBERNETES_NAMESPACE%
spec:
  parentRefs:
    - name: %GATEWAY_NAME%
      sectionName: http
  hostnames:
%ROUTE_HOST_NAMES%
  rules:
    - filters:
        - type: RequestRedirect
          requestRedirect:
            scheme: https
            statusCode: 301

```

```yaml
apiVersion: gateway.networking.k8s.io/v1
kind: HTTPRoute
metadata:
  name: %SERVICE_NAME%-route-443
  namespace: %KUBERNETES_NAMESPACE%
spec:
  parentRefs:
    - name: %GATEWAY_NAME%
  hostnames:
%ROUTE_HOST_NAMES%
  rules:
    - matches:
        - path:
            type: PathPrefix
            value: /
      backendRefs:
        - name: %SERVICE_NAME%
          port: 8080
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  SUB_DOMAIN_NAME: papi
  AZURE_GROUP_DNS: ${{ vars.AZURE_RESOURCE_GROUP_DNS }}
```

Additionally, during the Kubernetes deployment step, before any resources are applied, all DNS zones are iterated, and the hostname configured in the `httpRoutes` resource is updated to 
include the application's subdomain.

```powershell
$zoneNames = az network dns zone list -g $env:AZURE_GROUP_DNS --query "[].name" -o json | ConvertFrom-Json

$env:ROUTE_HOST_NAMES = (
    $zoneNames | ForEach-Object {
        "  - $env:SUB_DOMAIN_NAME.$_"
    }
) -join "`n"

$env:GATEWAY_NAME = kubectl get gateway -n $env:KUBERNETES_NAMESPACE -o jsonpath='{.items[0].metadata.name}'
```

The deployment commands have been updated to apply the new Kubernetes `HTTPRoute` templates.  
