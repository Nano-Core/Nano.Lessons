# Api.PolicyHeaders.ContentSecurityPolicy

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Hosting.Https]()

The Controller inherits from the topmost `BaseController` class in Nano.
The service is configured for https, as otherwise csp-reports are not send to the csp-reports endpoint by most browsers.

Load the `csp-violation.html` and see the browser reporting csp issues.

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
Added http header config with some reasonable values.

### Csp
For CSP there are many different possible configurtations. The example showcases some, but feel free to experiment and change the values and inspect the csp header.
The Csp configuration is large, so just to showcase i have included a few directives.

`Report-To` is enabled and configured to send reports to the default Nano endpoint `/csp/report-to`.
Be aware that it may take about a minute, and possible longer, before the browser sends the report. 

