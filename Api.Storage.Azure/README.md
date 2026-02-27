# Api.Storage.Azure

> _Nano API application with azure storage._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
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
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

The following storage has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(x =>
{
    x.AddNanoStorage<AzureFileshareProvider>();
})
...
```

This application demonstrates uploading a file and saving it to a mapped file share.  
When running locally, files are NOT written to the Azure File Share. Instead, Docker mounts a local directory to simulate the file share.  
Files are saved in `.docker/bin/`.  

A storage health check is configured to target the Azure File Share, but it requires valid credentials to be provided 
under `Storage.Account` in `secrets.json`.

```json
{
  "Storage:Account:Id": "id",
  "Storage:Account:Secret": "secret"
}
```

> ⚠️ If the account secrets are omitted from the configuration, the application will still run, but the healthcheck will report `degraded`.

Open [http://localhost:8080/healthz-ui](http://localhost:8080/healthz-ui) to view the storage health-check in the web-based UI.  

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#health-checks)**.  

The following endpoint is available for testing:

| Endpoint                                            | Description                                                                     |
| --------------------------------------------------- | ------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/storage-azure`  | Returns a simple `200 OK` response. Saves the uploaded file to the fileshare.   |

> 📖 Learn more about **[Nano Azure Storage](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Storage.Azure)**.

## Configuration
Add the storage configuration.  

```json
"Storage": {
  "ShareName": "nano-storage-azure",
  "Account": {
    "Id": "id",
    "Secret": "secret"
  },
  "HealthCheck": {
    "UnhealthyStatus": "Degraded"
  }
}
```

Additionally, application health-checks have been enabled with the configuration

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
Map the fileshare in docker-compose.  

```yaml 
docker
    volumes:
      - ./bin/nano-storage-azure:/mnt/nano-storage-azure
```

## Kubernetes
Add secrets and volumes to the `deployment.yaml`.  

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