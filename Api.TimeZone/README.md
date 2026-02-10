# Api.TimeZone

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Http]()

The Controller inherits from the topmost `BaseController` class in Nano.

The endpoints, both GET and POST version in the controller returns this response. 
Explanations are given for each date-time value in the response.
```json
{
    "RequestDateTimeLocal": "2026-02-08T14:23:45+03:00",    // The date-time sent from the client in the request.
    "ServerRecievedUtc": "2026-02-08T11:23:45Z",            // The date-time in utc that the server recieves.
    "ResponseDateTimeLocal": "2026-02-08T14:23:45+03:00",   // The date-tme in the response to the client.
    "DateTimeInfoNow": "2026-02-10T11:40:37+03:00",         // The current local date-time on the server.
    "DateTimeInfoUtcNow": "2026-02-10T08:40:37.7265135Z"    // The current utc date-time on the server.
}
```

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration
The default timezone indicates which timezone to use when `tz` parameter has been omitted from a request.
```json
"App": {
  "TimeZone": {
    "DefaultTimeZone": "UTC"
  }
}
```
