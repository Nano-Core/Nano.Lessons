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

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#health-checks)**.  

The following endpoint is available for testing.

| Endpoint                                            | Description                                                                     |
| --------------------------------------------------- | ------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/storage`        | Returns a simple `200 OK` response. Saves the uploaded file to the fileshare.   |

> 📖 Learn more about **[Nano.Storage.Azure](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Storage.Azure)**.

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
  "Credentials": {
    "Id": "id",
    "Secret": "secret"
  },
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
      - ./bin/nano-storage-azure:/mnt/nano-storage-azure
```

## Kubernetes
Added the volumes, volume mounts and secrets to the `deployment.yaml`.  

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

And add this step below as well, ensuring that the fileshare gets created before the application is deployed.  

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