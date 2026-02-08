# Api.ResponseCache

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Hosting.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

use the endpoints `/response-cache` to see that it uses cache based on configuration. `Cache-Control=public, max-age=1200`
use the endpoints `/no-response-cache` to see that cache has been disabled for that action (`[ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]`). `Cache-Control=no-store,no-cache`


## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
```json
"App": {
  "ResponseCache": {
    "MaxSize": 1024,
    "MaxBodySize": 102400,
    "MaxAge": "00:20:00"
  }
}
```
