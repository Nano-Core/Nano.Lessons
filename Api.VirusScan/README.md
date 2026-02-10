# Api.VirusScan

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

Invoke the endpoint. To trigger a virus scan exception use test-files from eicar: https://www.eicar.org/download-anti-malware-testfile

## Solution Items

## Docker 
```yaml
services:
  api.virusscan:
    depends_on:
      - clamav

  clamav: 
    image: clamav/clamav
    hostname: clamav
    ports:
      - 3310:3310
    networks:
      - network
```

## Kubernetes

## GitHub Actions

## Configuration
```json
"App": {
  "VirusScan": {
    "Host": "clamav",
    "Port": 3310,
    "HealthCheck": {
      "UnhealthyStatus": "Unhealthy"
    }
  }
}
```