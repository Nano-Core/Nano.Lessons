# Api.Storage.Local

> _Nano API application with local storage._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This applicationn demonstrates uplaoding a file and saving it to a locally mapped fileshare.  
Files are saved in `.docker/bin/`.  

Storage healthcheck has also been configured.  
Open [http://localhost:8080/healthz-ui](http://localhost:8080/healthz-ui) to view the storage health-check in the web-based UI.  

The following endpoint is available for testing:

| Endpoint                                            | Description                                                                     |
| --------------------------------------------------- | ------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/storage-local`  | Returns a simple `200 OK` response. Saves the uploaded file to the fileshare.   |

> 📖 Learn more about **[Nano Local Storage](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Storage.Local)**.

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
    "UnhealthyStatus": "Degraded"
  }
}
```

Additionally, application health-checks have been enabled with the configuration.

```json
"App": {
  "HealthCheck": {
    "EvaluationInterval": 10,
    "FailureNotificationInterval": 60,
    "MaximumHistoryEntriesPerEndpoint": 50
  }
}
```

## Docker Compose
Mapped the fileshare in `docker-compose.yml`.  

```yaml 
docker
    volumes:
      - ./bin/nano-storage-local:/mnt/nano-storage-local
```

## Kubernetes
Added the volumes and volume mounts to the `deployment.yaml`.  

```json
spec:
  template:
    spec:
      containers:
        volumeMounts:
        - name: %SERVICE_NAME%-volume
          mountPath: /mnt/%STORAGE_SHARE_NAME%
        - name: tmp
          mountPath: /tmp
      volumes:
      - name: %STORAGE_SHARE_NAME%
        emptyDir: {}
      - name: tmp
        emptyDir: {}
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
  STORAGE_SHARE_NAME: nano-storage-local
```
