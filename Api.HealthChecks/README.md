# Api.HealthChecks

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

Open http://localhost:8080/healthz-ui#/healthchecks and see that the startup health-check has completed, and reports healthy.

A webhook is configured for health-check. That would be hit when the service goes unhealty or????
It's made in the examples controller.

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
```json
"App": {
  "HealthCheck": {
    "UseHealthCheckUI": true,
    "EvaluationInterval": 10,
    "FailureNotificationInterval": 60,
    "MaximumHistoryEntriesPerEndpoint": 50,
    "WebHooks": [
      {
        "Name": "Test",
        "Url": "http://localhost:8080/api/examples/webhook",
        "Payload": null
      }
    ]
  }
}
```