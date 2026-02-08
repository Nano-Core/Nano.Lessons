# Api.Hosting.MultipartLimits

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Hosting.Http]()

Add multipart limits for file uploads, setting max upload size to 1 MB. 
Use the example controller to try out.


## Solution Items
No changes

## Docker 
No changes

## GitHub Actions
No changes

## Configuration

```json
Added
  "App": {
    "Hosting": {
      "MultipartLimits": {
        "MaxUploadBytes": 1048576,
        "KeepAliveTimeout": 30
      }
}
```
