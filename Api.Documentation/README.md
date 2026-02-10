# Api.Documentation

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

Run the solution and open http://localhost:8080/docs in your browser to load the api documentation.

Use can fiddle with the `UseDefaultVersion` setting, and see when `false` swagger displays bith a non-versioned route and a versioned for the same example endpoint. 
And when `true` swagger only displayed the non-versioned route for the default version of the application.

We have also added a nonce and setup csp script and style only to accept that nonce. The nonce value is also added to `Documentation.Nonce`, thus swagger scripts and
styles are allowed. If you try change the `Documentation.Nonce` you will see the swagger page breaks with csp script and style errors in the browser.
You can also remove the `HttpPolicyHeaders` in the `appsettings` and set the `Documentation.Nonce` to `null`.

Read more here about configuring nonce tokens for micro-service environment, e.g. Kubernetes.

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

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
      "Url": "https://github.com/Nano-Core/Nano.Library/blob/master/LICENSE"
    },
    "CspNonce": "927ba207fece4379bbd32f7d3ad55675",
    "UseDefaultVersion": true
  }
}
```
