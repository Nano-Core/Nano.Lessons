# Api.Documentation.Nonce

> _Nano API application with api documentation and nonce._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#gitHub-actions)

## Summary
This application builds on **[Api.Hosting.Https](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Hosting.Https)**.    

This example shows using API documentation with CSP security using nonce. Run the solution and open 
[https://localhost:4443/docs](https://localhost:4443/docs) in your browser to view the API documentation.  

Also a CSP nonce has been added and the policy configured to allow scripts and styles only with that nonce. The nonce value is available in `Documentation.Nonce`, 
ensuring that Swagger scripts and styles are permitted. If you change `Documentation.Nonce`, the Swagger page will break with CSP script and style errors in the browser.  
You can also remove the `HttpPolicyHeaders` from `appsettings` and set `Documentation.Nonce` to `null` to disable nonce enforcement.

| Endpoint                                           | Description          |
| -------------------------------------------------- | -------------------- |
| `http://localhost:8080/api/examples/documentation` | Returns a `200 OK`.  |

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#documentation)**.

## Configuration

```json
"App": {
  "Documentation": {
    "Name": "Application",
    "Description": "This is an example application",
    "TermsOfService": "https://github.com/Nano-Core/Nano.Library/blob/master/LICENSE",
    "Contact": {
      "Name": "Nano Contributors",
      "Email": "email@email.com",
      "Url": "https://github.com/Nano-Core"
    },
    "License": {
      "Name": "MIT",
      "Identifier": "MIT",
      "Url": "https://github.com/Nano-Core/Nano.Library/blob/master/LICENSE"
    },
    "CspNonce": "927ba207fece4379bbd32f7d3ad55675",
    "HideDefaultVersion": true
  }
}
```

## Kubernetes
Annotations are configured below to automatically replace the static CSP nonce with a dynamically generated token, 
ensuring that scripts and styles comply with the Content Security Policy.

```
kind: Ingress
metadata:
  annotations:
    nginx.ingress.kubernetes.io/configuration-snippet: | 
      more_set_headers "Content-Security-Policy: script-src 'self' 'nonce-${request_id}'; style-src 'self' 'nonce-${request_id}'";
      sub_filter_once off;
      sub_filter '%NONCE_TOKEN%' $request_id;
      sub_filter '(<body[^>]*>)(.*?)%NONCE_TOKEN%(.*?<\/body>)' '$1$2"$request_id"$3';
```

## GitHub Actions
Additional environment variables have been added to `build-and-deploy.yml` to support the new Kubernetes resources:

```yaml
env:
  NONCE_TOKEN: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_NONCE_TOKEN || secrets.STAGING_NONCE_TOKEN }}
```
