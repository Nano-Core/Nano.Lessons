# Api.PolicyHeaders.ContentSecurityPolicy

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Hosting.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

Invoke the endpoints and observe the `X-Robots-Tag` set in the response.

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "Robots": {
      "UseNoIndex": true,
      "UseNoFollow": true,
      "UseNoSnippet": true,
      "UseNoArchive": true,
      "UseNoOdp": true,
      "UseNoTranslate": true,
      "UseNoImageIndex": true
    }
  }
}
```