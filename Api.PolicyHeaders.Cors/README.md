# Api.PolicyHeaders.Cors

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Hosting.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

Check the different html pages for different cors violations.

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
```json 
"Cors": {
  "AllowedOrigins": [
    "http://localhost:8080"
  ],
  "AllowedHeaders": [
    "*"
  ],
  "AllowedMethods": [
    "GET",
    "POST"
  ],
  "AllowCredentials": true,
  "Origin": {
    "EmbedderPolicy": "UnsafeNone",
    "OpenerPolicy": "SameOriginAllowPopups",
    "ResourcePolicy": "SameOrigin"
  }
}
```
