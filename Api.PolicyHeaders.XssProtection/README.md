# Api.PolicyHeaders.XssProtection

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Hosting.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

Run the endpoint and see the headers xxs protection header
Load the html page and observe the `alert` not being shown, but blocked.


X-XSS-Protection is deprecated and ignored by:
* Chrome
* Edge Chromium
* Firefox
This header is basically legacy defense-in-depth, and replaced by `Content-Security-Policy`


## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
```json
"App": {
  "HttpPolicyHeaders": {
    "XssProtection": {
      "XssProtectionPolicyHeader": "FilterEnabledBlockMode"
    }
  }
}
```