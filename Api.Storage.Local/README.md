# Api.Storage.Local

> _Nano API application with local storage._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This application demonstrates uploading a file and saving it to a locally mapped fileshare.  
Files are saved in `.docker/bin/`.  

Storage health-check has also been configured.  
Open [http://localhost:8080/healthz](http://localhost:8080/healthz) to view the storage health-check in the JSON response.  

The following endpoint is available for testing:

| Endpoint                                      | Description                                                                     |
| --------------------------------------------- | ------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/storage`  | Returns a simple `200 OK` response. Saves the uploaded file to the fileshare.   |

> 📖 Learn more about **[Nano.Storage.Local](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Storage.Local/README.md#nanostoragelocal)**.

## Registration
The following storage has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(x =>
{
    x.AddNanoStorage<LocalFileShareProvider>();
})
...
```

## Configuration
Configured the application with the necessary storage setup.  

```json
"Storage": {
  "ShareName": "nano-storage-local",
  "HealthCheck": {
    "UnhealthyStatus": "Unhealthy"
  }
}
```

Additionally, application health-checks have been enabled with the configuration.

```json
"App": {
  "HealthCheck": {
  }
}
```

## Docker Compose
Mapped the fileshare in `docker-compose.yml`.  

```yaml 
services:
  api.storage.local:
    volumes:
      - ./bin/nano-storage-local:/mnt/nano-storage-local
```

## Kubernetes
Added `storage-storageclass.yaml`, for dynamically provisioning the local fileshare's disks.

A locally-mounted fileshare is single-attach (`ReadWriteOnce`) — a plain `Deployment` can't give each replica its own disk, since every replica shares one pod template and would otherwise race
to attach the same volume. So `deployment.yaml` was replaced with `stateful-set.yaml` (`kind: StatefulSet`), using `volumeClaimTemplates` instead of a single static `PersistentVolumeClaim` file,
this gives each replica pod its own separate, uniquely-named disk automatically (note: each pod's files are then isolated from the others, not shared).

```yaml
spec:
  serviceName: %SERVICE_NAME%-stateful-headless
  template:
    spec:
      containers:
        volumeMounts:
        - name: %SERVICE_NAME%-volume
          mountPath: /mnt/%STORAGE_SHARE_NAME%
        - name: tmp
          mountPath: /tmp
      volumes:
      - name: tmp
        emptyDir: {}
  volumeClaimTemplates:
  - metadata:
      name: %SERVICE_NAME%-volume
    spec:
      accessModes:
        - ReadWriteOnce
      storageClassName: %SERVICE_NAME%-storage-class
      resources:
        requests:
          storage: %STORAGE_SIZE%Gi
```

A `StatefulSet` requires a governing headless service (`clusterIP: None`) for its `serviceName` field — added as `service-headless.yaml`, alongside the existing `service.yaml` which continues
to handle normal traffic routing.

The `autoscaler.yaml`'s `HorizontalPodAutoscaler` also had its `scaleTargetRef.kind` updated from `Deployment` to `StatefulSet`.

```yaml
spec:
  scaleTargetRef:
    kind: StatefulSet
```

## GitHub Actions
Add the following environment variables to the `build-and-deploy.yml`.  

```yaml
env:
  STORAGE_SHARE_NAME: nano-storage-local
  STORAGE_SIZE: 1000
```

Deployment commands have also been updated to apply each of the new Kubernetes templates.  
