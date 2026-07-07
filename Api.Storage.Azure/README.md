# Api.Storage.Azure

> _Nano API application with azure storage._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

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

This application demonstrates uploading a file and saving it to a mapped file share.  
When running locally, files are **NOT** written to the Azure File Share. Instead, Docker mounts a local directory to simulate the file share.  
Files are saved in `.docker/bin/`.  

A storage health check is configured to target the Azure File Share, but it requires valid credentials to be provided under `Storage.Credentials`. If the 
credentials are omitted from the configuration, the application will still run, but the health-check will report `degraded`.  

Open [http://localhost:8080/healthz](http://localhost:8080/healthz) to view the storage health-check JSON response.  

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#health-checks)**.  

The following endpoint is available for testing.

| Endpoint                                            | Description                                                                     |
| --------------------------------------------------- | ------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/storage`        | Returns a simple `200 OK` response. Saves the uploaded file to the fileshare.   |

> 📖 Learn more about **[Nano.Storage.Azure](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Storage.Azure/README#nanostorageazure)**.

## Registration
The following storage provider has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(x =>
{
    x.AddNanoStorage<AzureFileshareProvider>();
})
...
```

## Configuration
Add the storage configuration.  

```json
"Storage": {
  "ShareName": "nano-storage-azure",
  "HealthCheck": {
    "AccountName": null,
    "UnhealthyStatus": "Degraded"
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
  svc.accounts:
    volumes:
      - ./bin/nano-storage-azure:/mnt/nano-storage-azure
```

## Kubernetes
Added two new kubernetes templaets, the `storage-pv.yaml` and `storage-pvc.yaml`. Updated the `deployment.yaml` mounting the volume.  

```yaml
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
          claimName: %SERVICE_NAME%-azurefile-pvc
      - name: tmp
        emptyDir: {}
```

Additionally, the `configmap.yaml` file stores the `$env:STORAGE_ACCOUNT_NAME` value, which is used by the TCP-based health check to validate connectivity to the Azure File Share endpoint.  

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env: 
  AZURE_GROUP_BACKUP: ${{ vars.AZURE_RESOURCE_GROUP_BACKUP }}
  AZURE_GROUP_STORAGE: ${{ vars.AZURE_RESOURCE_GROUP_STORAGE }}
  STORAGE_SIZE: 1000
  STORAGE_SHARE_NAME: nano-storage-azure
```

And add this step below as well, ensuring that the fileshare gets created before the application is deployed.  

```yaml
- name: Create Fileshare
shell: pwsh
run: |
    $env:STORAGE_ACCOUNT_NAME = az storage account list -g $env:AZURE_GROUP_STORAGE --query [0].name -o tsv;

    $env:FILE_SHARE_EXISTS = az storage share-rm exists `
        -g $env:AZURE_GROUP_STORAGE `
        -n $env:STORAGE_SHARE_NAME `
        --storage-account $env:STORAGE_ACCOUNT_NAME `
        --query exists;

    if ($env:FILE_SHARE_EXISTS -eq "false")
    { 
        az storage share-rm create `
            -g $env:AZURE_GROUP_STORAGE `
            -n $env:STORAGE_SHARE_NAME `
            --storage-account $env:STORAGE_ACCOUNT_NAME `
            --access-tier TransactionOptimized `
            --quota $env:STORAGE_SIZE;
    }
    else
    {
        az storage share-rm update `
            -g $env:AZURE_GROUP_STORAGE `
            -n $env:STORAGE_SHARE_NAME `
            --storage-account $env:STORAGE_ACCOUNT_NAME `
            --access-tier TransactionOptimized `
            --quota $env:STORAGE_SIZE;
    }

    if ($LastExitCode -ne 0) 
    { 
        throw "error";
    };

    $env:BACKUP_VAULT_NAME = az backup vault list -g $env:AZURE_GROUP_BACKUP --query [0].name -o tsv;

    az backup protection enable-for-azurefileshare `
        -g $env:AZURE_GROUP_BACKUP `
        -v $env:BACKUP_VAULT_NAME `
        -p $env:STORAGE_ACCOUNT_NAME-fileshare-backup-policy `
        --storage-account $env:STORAGE_ACCOUNT_NAME `
        --azure-file-share $env:STORAGE_SHARE_NAME;

    if ($LastExitCode -ne 0) 
    { 
        throw "error";
    };
```
