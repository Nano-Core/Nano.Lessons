# Api.PolicyHeaders.ForwardedHeaders

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Hosting.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

Invoke the endpoint in example controller and see the updated scheme, host and remote ip-address. The original headers are also included in the response, and they should 
not be the same, but the internal ones from the service, not coming from the "forwarded" request.
The example request has added 3 "X-Forwarded" headers, simulating a reverse proxy request


## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "ForwardedHeaders": {
      "Headers": "All",
      "RequireHeaderSymmetry": true
    }
  }
}
```
