# Api.PolicyHeaders.ContentSecurityPolicy

> _Nano API application with content security policy (CSP)._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Hosting.Https](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.Hosting.Https)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

Content Security Policy (CSP) supports a wide range of configurations. This example demonstrates a small, representative subset of directives to illustrate 
how CSP is configured and applied. You are encouraged to experiment with the settings and inspect the resulting `Content-Security-Policy` response header 
to better understand their effects.

The service is configured to run over HTTPS, as most browsers will not send CSP violation reports to a `csp-report` endpoint over HTTP. 
The `Report-To` directive is enabled and configured to send reports to Nano’s default endpoint at `/csp/report-to`. 

> ⚠️ Browsers typically batch and delay CSP reports, so it may take up to a minute—or longer—before reports are sent.

To observe CSP violations in action, load the provided `csp-violation.html` file and inspect the browser’s reporting behavior.

| Endpoint                                 | Description                                                     |
| ---------------------------------------- | --------------------------------------------------------------- |
| `http://localhost:8080/api/examples/csp` | Returns a `200 OK` response including the CSP response header.  |

> 📖 Learn more about **[Nano Content Security Policy](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#content-security-policy-csp)**.

## Configuration
Added content security policy header configuration.  

```json
"App": {
  "HttpPolicyHeaders": {
    "Csp": {
      "ReportOnly": false,
      "UpgradeInsecureRequests": true,
      "Defaults": {
        "IsNone": false,
        "IsSelf": true,
        "Sources": [
          "https://localhost"
        ]
      },
      "Scripts": {
        "IsNone": false,
        "IsSelf": true,
        "IsUnsafeInline": false,
        "IsUnsafeEval": false,
        "IsUnsafeWasmEval": false,
        "IsTrustedTypesEval": false,
        "IsUnsafeHashes": false,
        "StrictDynamic": false,
        "UnsafeHashedAttributes": false,
        "UnsafeAllowRedirects": false,
        "InlineSpeculationRules": false,
        "Sources": [
        ],
        "Nonces": [
        ],
        "Hashes": [
        ],
        "RequireTrustedTypes": false,
        "RequireSri": false,
        "ReportSample": true
      },
      "Styles": {
        "IsNone": false,
        "IsSelf": true,
        "IsUnsafeInline": false,
        "IsUnsafeHashes": false,
        "Sources": [
        ],
        "Nonces": [
        ],
        "Hashes": [
        ],
        "RequireSri": false,
        "ReportSample": true
      },
      "StylesElem": {
        "IsNone": false,
        "IsSelf": true,
        "IsUnsafeInline": false,
        "Sources": [
        ],
        "Nonces": [
        ],
        "Hashes": [
        ],
        "ReportSample": true
      },
      "StylesAttr": {
        "IsNone": false,
        "IsSelf": true,
        "IsUnsafeInline": false,
        "IsUnsafeHashes": false,
        "Sources": [
        ],
        "ReportSample": true
      },
      "PermissionsPolicy": {
        "Gamepad": {
          "IsNone": false,
          "IsSelf": true,
          "Sources": [
          ]
        }
      },
      "ReportTo": {
        "Group": "csp-reports",
        "MaxAge": "60",
        "Endpoints": [
        ]
      }
    }
  }
}
```
