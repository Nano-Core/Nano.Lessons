# Api.Metrics

> _Nano API application with OpenTelemetry metrics configured._  
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
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api._Blank)**.

This example demonstrates how OpenTelemetry can be configured to expose metrics through `/metrics`. Try it out.

| Endpoint                             | Description                                      |
| ------------------------------------ | ------------------------------------------------ |
| `http://localhost:8080/api/metrics`  | Returns the current metrics for the application. |

> 📖 Learn more about **[Nano OpenTelemetry Metrics](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#opentelemetry-metrics)**.

## Configuration
Added the empty `Metrics` section to enable OpenTelemetry with Prometheus for the application.

```json
"App": {
  "Metrics": {
  }
}
```

## Kubernetes
Added the new `service-monitor` template to the application.

```yaml
apiVersion: azmonitoring.coreos.com/v1
kind: ServiceMonitor
metadata:
  name: %SERVICE_NAME%-monitor
  namespace: %KUBERNETES_NAMESPACE%
spec:
  selector:
    matchLabels:
      app.kubernetes.io/name: %SERVICE_NAME%
  endpoints:
    - port: http
      path: /metrics
      interval: 1m
```

## GitHub Actions
The deployment commands have been updated to apply the new Kubernetes `ServiceMonitor` template.  
