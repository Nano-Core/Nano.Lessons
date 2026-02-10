# Nano.Lessons


Where to place. "Remember: Set the `docker-compose` as startup project before running the solution"


## Nano application structure
Show the folder (.Kubernetes, .gitHub, .test, etc) and describe the purpose, etc.


- Models project is configured for packaging a NuGet, which should be published internally and used to connect api to services.
  Also why the Nano dependences must be added here.


## To rename a blank solution
docker-compose
services:
  api.policyheaders.contenttype:
    image: api.policyheaders.contenttype
    hostname: api-policyheaders-contenttype
    build:
      context: ../Api.PolicyHeaders.ContentType

.GitHub build-and-deploy
env:
  APP_NAME: Api.PolicyHeaders.ContentType
  IMAGE_NAME: api.policyheaders.contenttype
  SERVICE_NAME: api-policyheaders-contenttype

rename csproj/sln files and rename all referenced projects
- Api.PolicyHeaders.XssProtection.sln
- Api.PolicyHeaders.XssProtection.csproj
- Api.PolicyHeaders.XssProtection.Models.csproj
- Tests.Api.PolicyHeaders.XssProtection.csproj

- change in /Api.PolicyHeaders.XssProtection/Properties/InternalsVisibleTo

Dockerfile / Dockerfile.local
rename Entry Point