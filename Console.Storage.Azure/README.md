# Console.Storage.Azure

> _Nano Console application with azure storage._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the [Nano.Library](https://github.com/Nano-Core/Nano.Library) repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Console.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Console._Blank)**.  

The following storage has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(x =>
{
    x.AddNanoStorage<AzureFileshareProvider>();
})
...
```

This application demonstrates creating a file and saving it to a mapped file share.  
When running locally, files are NOT written to the Azure File Share. Instead, Docker mounts a local directory to simulate the file share.  
Files are saved in `.docker/bin/`.  

> 📖 Learn more about **[Nano Azure Storage](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Storage.Azure)**.

## Configuration
Add the storage configuration.  

```json
"Storage": {
  "ShareName": "nano-storage-azure",
  "Account": {
    "Id": "id",
    "Secret": "secret"
  }
}
```

## Docker Compose
Map the fileshare in docker-compose.  

```yaml 
docker
    volumes:
      - ./bin/nano-storage-azure:/mnt/nano-storage-azure
```

## Kubernetes
Add the following to the `deployment.yaml`.  

```json
spec:
  template:
    spec:
      containers:
        env:
        - name: Storage__AccountName
          valueFrom:
            secretKeyRef:
              name: storage-account-secret
              key: azurestorageaccountname
        - name: Storage__AccountKey
          valueFrom:
            secretKeyRef:
              name: storage-account-secret
              key: azurestorageaccountkey
        volumeMounts:
        - name: tmp
          mountPath: /tmp
        - name: %SERVICE_NAME%-volume
          mountPath: /mnt/%STORAGE_SHARE_NAME%
      volumes:
      - name: tmp
        emptyDir: {}
      - name: %SERVICE_NAME%-volume
        azureFile:
          secretName: storage-account-secret
          shareName: %STORAGE_SHARE_NAME%
          readOnly: false
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml` 

```yaml
STORAGE_SHARE_NAME: nano-storage-azure
STORAGE_ACCOUNT_NAME: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_STORAGE_ACCOUNT_NAME  || secrets.STAGING_STORAGE_ACCOUNT_NAME }}
STORAGE_ACCOUNT_KEY: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_STORAGE_ACCOUNT_KEY  || secrets.STAGING_STORAGE_ACCOUNT_KEY }}
STORAGE_SIZE: 1000
```

And add this step below as well, ensuring that the fileshare gets created before the application is deployed.  
```yaml
- name: Create Fileshare
  shell: pwsh
  run: |
    $env:EXISTING_FILE_SHARE = sudo az storage share list --account-name $env:STORAGE_ACCOUNT_NAME --account-key $env:STORAGE_ACCOUNT_KEY --query "[?contains(name, '$env:STORAGE_SHARE_NAME')].[name]" -o tsv;
    if ([string]::IsNullOrEmpty($env:EXISTING_FILE_SHARE))
    { 
        sudo az storage share create -n $env:STORAGE_SHARE_NAME --account-name $env:STORAGE_ACCOUNT_NAME --account-key $env:STORAGE_ACCOUNT_KEY --quota $env:STORAGE_SIZE;
        if ($LastExitCode -ne 0) 
        { 
            throw "error";
        };  
    }
```