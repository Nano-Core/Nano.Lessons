# Api.PolicyHeaders.Hsts

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Hosting.Https]()

The Controller inherits from the topmost `BaseController` class in Nano.
The service is configured for https, as otherwise hsts can't be tested.

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "Hsts": {
      "MaxAge": "00:01:00",
      "UsePreload": false,
      "IncludeSubdomains": false
    }
  }
}
```
