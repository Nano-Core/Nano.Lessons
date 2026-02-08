# Api.ResponseCompression

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

Run the `compressed` endpoint and inspect the size and the headers: Expected headers (`Content-Encoding: gzip` and `Vary: Accept-Encoding`)
Run the `uncompressed` endpoint where the request header for supporting response compression has been removed, and see the headers are missing, and the size and that it's not response is not compressed .

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
```json
"App": {
  "ResponseCompression": {
    "UseGzip": true,
    "UseBrotli": true
  }
}
``´