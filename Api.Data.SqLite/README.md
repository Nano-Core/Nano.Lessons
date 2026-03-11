# Api.Data.SqLite

> _Nano API application with sqlite data._  
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
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a test controller that inherits from 
the Nano `BaseEntityControllerr<TEntity, TCriteria>`. The available entity endpoints are inherited, and no additional endpoints has been added.  

This example demonstrates how various parts of Nano data work together. All data configuration and registration have been completed, and classes have been implemented 
for the data parts, including [Data Models](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-models), [Data Mappings](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-mappings), 
and the [Data Context](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-context).  

Additionally, the example shows how Nano [Data Repository](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#repositories) works along with the corresponding 
entity controllers. For more information on controllers and how they are connected with entity models, see [Nano Entity Controllers](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#controllers).

A data health check is configured to target the database.  
Open the health-check UI here to view the database health status: **[http://localhost:8080/healthz-ui](http://localhost:8080/healthz-ui)**.  

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#health-checks)**.

Also, API documentation has been configured, in order to easier see which endpoints are available. It can be accessed 
here: **[http://localhost:8080/docs](http://localhost:8080/docs)**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

Additionally, controllers have been implemented to demonstrate controllers for creatable, updatable, creatable-and-updatable, and deletable entities. When viewing 
the API documentation, observe how the available endpoints differ depending on the capabilities supported by each controller.  

> 📖 Learn more about **[Nano Data SqLite](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.SqLite)**.

## Registration
The following data provider has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(services =>
{
    services
        .AddNanoData<SqLiteProvider, SqLiteDbContext>();
})
...
```

Also, an initial migration has been added to the project.

```powershell
dotnet ef migrations add Initial --project Api.Data.SqLite
```

## Configuration
Configured the application with the necessary data setup.  

```json
"Data": {
  "BatchSize": 25,
  "BulkBatchSize": 500,
  "BulkBatchDelay": 1000,
  "QueryRetryCount": 0,
  "UseLazyLoading": false,
  "UseCreateDatabase": false,
  "UseMigrateDatabase": false,
  "UseSoftDeletetion": false,
  "UseSensitiveDataLogging": false,
  "UseAudit": false,
  "QuerySplittingBehavior": "SingleQuery",
  "DefaultCollation": null,
  "ConnectionString": "Data Source=/data/nanoDb.sqlite",
  "Repository": {
    "UseAutoSave": false,
    "QueryIncludeDepth": 4
  },
  "Identity": null,
  "ConnectionPool": null,
  "HealthCheck": {
    "UnhealthyStatus": "Unhealthy"
  }
}
```

...and `appsettings.Development.json`

```json
"Data": {
  "UseMigrateDatabase": true
}
```

## Docker Compose
Added SqLite as a service dependency in `docker-compose.yml`.  

```yaml
services:
  api.data.sqlite:
    volumes:
      - ./bin/data:/data
```

Also the `Dockerfile` must have SqLite installed with spatial support. Add the following to both the `Dockerfile` and the `Dockerfile.Local`.  

```dockerfile
RUN apt-get update \
    && apt-get install -y libsqlite3-mod-spatialite \
    && apt-get install -y libspatialite-dev
```

## Kubernetes
Added two additional kubernetes templates, `storageclass.yaml` and `pvc.yaml`, for dynamically manage and creating the disk for the SqLite database.

Also, updated `deployment.yaml` adding the volumes and volume mounts.  

```json
spec:
  template:
    spec:
      containers:
        volumeMounts:
        - name: %SERVICE_NAME%-volume
          mountPath: /mnt/%STORAGE_SHARE_NAME%
      volumes:
      - name: %SERVICE_NAME%-volume
        persistentVolumeClaim:
          claimName: %SERVICE_NAME%-pvc
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  DATA_NAME: nanoDb
  DATA_SIZE: 10Gi
  DATA_CONNECTIONSTRING: "Data Source=/data/{{ env.nanoDb }}.sqlite"
```

Additionally, this step has been added to ensure database migrations are applied.  

```yaml
- name: Database Migration
  shell: pwsh
  run: |
    dotnet ef database update `
      --no-build `
      --startup-project $env:APP_NAME `
      --connection "$env:DATA_MIGRATION_CONNECTIONSTRING" `;

    if ($LastExitCode -ne 0)
    { 
        throw "error";
    };
```

Deployment commands have also been updated to apply each of the new Kubernetes templates.  

```powershell
Get-Content .kubernetes/{resource-name}.yaml `
    | foreach { [Environment]::ExpandEnvironmentVariables($_) } `
    | Set-Content .kubernetes/{resource-name}.tmp.yaml;

sudo kubectl apply -f .kubernetes/{resource-name}.tmp.yaml;
```
