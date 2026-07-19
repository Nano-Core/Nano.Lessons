# Console.Storage.Local

> _Nano Console application with local storage._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the [Nano.Library](https://github.com/Nano-Core/Nano.Library) repository must be checked out in the same root directory. 
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
This application builds on **[Console.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Console._Blank)**.  

This application demonstrates creating a file and saving it to a locally mapped file-share.  
Files are saved in `.docker/bin/`.  

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
  "ShareName": "nano-storage-local"
}
```

## Docker Compose
Mapped the fileshare in `docker-compose.yml`.  

```yaml 
services:
  console.storage.local:
    volumes:
      - ./bin/nano-storage-local:/mnt/nano-storage-local
```

## Kubernetes
Added two additional kubernetes templates, `storage-storageclass.yaml` and `storage-pvc.yaml`, for dynamically manage and creating the local fileshare.

Also, updated `cronjob.yaml` adding the volumes and volume mounts.  

```yaml
spec:
  jobTemplate:
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
          - name: %SERVICE_NAME%-volume
            persistentVolumeClaim:
              claimName: %SERVICE_NAME%-pvc
          - name: tmp
            emptyDir: {}
```

## GitHub Actions
Added the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  STORAGE_SHARE_NAME: nano-storage-local
  STORAGE_SIZE: 1000
```

Deployment commands have also been updated to apply each of the new Kubernetes templates.  
