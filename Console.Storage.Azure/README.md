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

> 📖 Learn more about **[Nano.Storage.Azure](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Storage.Azure)**.

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
  "ShareName": "nano-storage-azure",
  "Credentials": {
    "Id": null,
    "Secret": null
  }
}
```

...and in `appsettings.Development.json`.

```json
"Storage": {
  "Credentials": {
    "Id": "id",
    "Secret": "secret"
  }
}
```

## Docker Compose
Mapped the fileshare in `docker-compose.yml`.  

```yaml 
docker
    volumes:
      - ./bin/nano-storage-azure:/mnt/nano-storage-azure
```

## Kubernetes
Added the volumes, volume mounts and secrets to the `cronjob.yaml`.  

```json
spec:
  template:
    spec:
      containers:
        env:
        - name: Storage__Credentials__Id
          valueFrom:
            secretKeyRef:
              name: storage-account-secret
              key: azurestorageaccountname
        - name: Storage__Credentials__Secret
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
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  STORAGE_SHARE_NAME: nano-storage-azure
  STORAGE_CREDENTIALS_ID: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_STORAGE_CREDENTIALS_ID  || secrets.STAGING_STORAGE_CREDENTIALS_ID }}
  STORAGE_CREDENTIALS_SECRET: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_STORAGE_CREDENTIALS_SECRET  || secrets.STAGING_STORAGE_CREDENTIALS_SECRET }}
  STORAGE_SIZE: 1000
```

Additionally, this step has been added to ensure the file share is created before the application is deployed.  

```yaml
- name: Create Fileshare
  shell: pwsh
  run: |
    $env:EXISTING_FILE_SHARE = sudo az storage share list --account-name $env:STORAGE_CREDENTIALS_ID --account-key $env:STORAGE_CREDENTIALS_SECRET --query "[?contains(name, '$env:STORAGE_SHARE_NAME')].[name]" -o tsv;
    if ([string]::IsNullOrEmpty($env:EXISTING_FILE_SHARE))
    { 
        sudo az storage share create -n $env:STORAGE_SHARE_NAME --account-name $env:STORAGE_CREDENTIALS_ID --account-key $env:STORAGE_CREDENTIALS_SECRET --quota $env:STORAGE_SIZE;
        if ($LastExitCode -ne 0) 
        { 
            throw "error";
        };  
    }
```