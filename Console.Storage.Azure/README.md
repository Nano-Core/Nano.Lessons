# Console.Storage.Azure

> _Nano Console application with azure storage._  
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
This application builds on **[Console.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Console._Blank)**.  

This application demonstrates creating a file and saving it to a mapped file share.  
When running locally, files are **NOT** written to the Azure File Share. Instead, Docker mounts a local directory to simulate the file share.  
Files are saved in `.docker/bin/`.  

> 📖 Learn more about **[Nano.Storage.Azure](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Storage.Azure/README#nanostorageazure)**.

## Registration
The following storage has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(x =>
{
    x.AddNanoStorage<AzureFileshareProvider>();
})
...
```

## Configuration
Configured the application with the necessary storage setup.  

```json
"Storage": {
  "ShareName": "nano-storage-azure"
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
Added two new kubernetes templaets, the `storage-pv.yaml` and `storage-pvc.yaml`. Updated the `cronjob.yaml` mounting the volume.  

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

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  AZURE_GROUP_BACKUP: ${{ vars.AZURE_BACKUP_RESOURCE_GROUP }}
  AZURE_GROUP_STORAGE: ${{ vars.AZURE_STORAGE_RESOURCE_GROUP }}
  STORAGE_SIZE: 1000
  STORAGE_SHARE_NAME: nano-storage-azure
```

Additionally, this step has been added to ensure the file share is created before the application is deployed.  

```yaml
- name: Create Fileshare
  shell: pwsh
  run: |
    $env:STORAGE_ACCOUNT_NAME = sudo az storage account list -g $env:AZURE_GROUP_STORAGE --query [0].name -o tsv;

    $env:FILE_SHARE_EXISTS = sudo az storage share-rm exists `
        -g $env:AZURE_GROUP_STORAGE `
        -n $env:STORAGE_SHARE_NAME `
        --storage-account $env:STORAGE_ACCOUNT_NAME `
        --query exists;

    if ($env:FILE_SHARE_EXISTS -eq "false")
    { 
        sudo az storage share-rm create `
            -g $env:AZURE_GROUP_STORAGE `
            -n $env:STORAGE_SHARE_NAME `
            --storage-account $env:STORAGE_ACCOUNT_NAME `
            --access-tier TransactionOptimized `
            --quota $env:STORAGE_SIZE;
              
        if ($LastExitCode -ne 0) 
        { 
            throw "error";
        };

        $env:BACKUP_VAULT_NAME = sudo az backup vault list -g $env:AZURE_GROUP_BACKUP --query [0].name -o tsv;

        sudo az backup protection enable-for-azurefileshare `
            -g $env:AZURE_GROUP_BACKUP `
            -v $env:BACKUP_VAULT_NAME `
            -p $env:STORAGE_ACCOUNT_NAME-backup-policy `
            --storage-account $env:STORAGE_ACCOUNT_NAME `
            --azure-file-share $env:STORAGE_SHARE_NAME;
              
        if ($LastExitCode -ne 0) 
        { 
            throw "error";
        };
    }
```