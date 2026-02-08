# Api.Hosting.Https

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Blank]()


The following endpoints are avaialble
These will be redirected to https
http://localhost:8080/api/examples/https
http://localhost:8080/api/v1/examples/https
http://localhost:8080/api/v1.0/examples/https

https://localhost:4443/api/examples/https
https://localhost:4443/api/v1/examples/https
https://localhost:4443/api/v1.0/examples/https

The Controller inherits from the topmost `BaseController` class in Nano.




## Solution Items
Added `localhost.pfx` self-signed certificate

## Docker 
Added the following to docker-compose.

```yaml
services:
  nano.api.hosting.https:
    ports:
      - 4443:4443
    volumes:
      - ../:/root/.dotnet/https
```

## Kubernetes
Added Certificate and Ingress resource.

## GitHub Actions
Added env vars:
  CERTIFICATE_ISSUER: letsencrypt-prod
  CERTIFICATE_ORGANIZATION: ${{ vars.CERTIFICATE_ORGANIZATION }}
  CERTIFICATE_HOST: ${{ github.ref == 'refs/heads/master' && vars.HOST_API_SUBDOMAIN + '.' + vars.PRODUCTION_HOST || vars.HOST_API_SUBDOMAIN + '.' + vars.STAGING_HOST }}


## Configuration
For `appsettings.Development.json`:

Notice it's only added to `Development` config, because in live environments we use ingress to control https.

```json
"App": {
  "Hosting": {
    "http": {
      "UseHttpsRedirection": true
    },
    "Https": {
      "Ports": [
        4443
      ],
      "Certificate": {
        "Path": "/root/.dotnet/https/localhost.pfx",
        "Password": "password"
      },
      "UseHttpsRequired": true
    }
  }
}
```
NOTE: We only have https and certificate configured for Development, beceuase in Kubernetes the certificates will be handled differently, 
and we still only need to expose a http port 8080 in `service.yaml` for mapping with the ingress resource.

NOTE: We don't use defualt ports (80, 443) because that will later trigger a security warning in Kubernetes. 