# Api.Hosting.Http

All lesions are complete examples showing both the specific feature but also GitHub actions, Kubernetes, etc required to deploy it. Just copy an example lesion to
it's own repository and try it.

Based on [Api.Blank]()

This solution are not much different from the [Api.Blank](). It just has a controller with an action for testing.

The following endpoints are avaialble
https://localhost:8080/api/examples/http
https://localhost:8080/api/v1/examples/http
https://localhost:8080/api/v1.0/examples/http

The Controller inherits from the topmost `BaseController` class in Nano.

## Solution Items

## Docker 

## Kubernetes

## GitHub Actions

## Configuration

NOTE: We don't use defualt ports (80) because that will later trigger a security warning in Kubernetes. 