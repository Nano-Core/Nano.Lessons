# Api.PolicyHeaders.ContentType

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Hosting.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

Load the `content-type-sniff-violation.html` and see the browser rejecting executing the script having incorrect `.txt` content-type.

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "ContentType": {
      "NoSniff": true
    }
  }
}
```
