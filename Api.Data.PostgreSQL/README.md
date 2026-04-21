# Api.Data.PostgreSQL

> _Nano API application with postgre sql data._  
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

> 📖 Learn more about **[Nano.Data.PostgreSQL](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.PostgreSQL)**.

## Registration
The following data provider has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(services =>
{
    services
        .AddNanoData<PostgreSqlProvider, PostgreSqlDbContext>();
})
...
```

Also, an initial migration has been added to the project.

```powershell
dotnet ef migrations add Initial --project Api.Data.PostgreSQL
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
  "StartupAction": "None",
  "UseSensitiveDataLogging": false,
  "QuerySplittingBehavior": "SingleQuery",
  "DefaultCollation": null,
  "ConnectionString": null,
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
  "StartupAction": "Migrate",
  "ConnectionString": "Host=host.docker.internal;Port=5432;Database=nanoDb;Username=sa;Password=myPassword_123"
}
```

## Docker Compose
Added PostgreSQL as a service dependency in `docker-compose.yml`.  

```yaml
services:
  api.data.postgresql:
    depends_on:
      - database

  database:
    image: postgis/postgis:latest
    ports:
      - 5432:5432
    networks:
      - network
    environment:
      POSTGRES_USER: sa
      POSTGRES_PASSWORD: myPassword_123
      POSTGRES_DB: nanoDb
```

## Kubernetes
Added the `%SERVICE_NAME%-secret` for the connectionstring to the `deployment.yaml`.  

```json
spec:
  template:
    spec:
      containers:
        env:
        - name: Data__ConnectionString
          valueFrom:
            secretKeyRef:
              name: %SERVICE_NAME%-data-secret
              key: data-connectionstring
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  DATA_HOST: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_POSTGRE_HOST || secrets.STAGING_POSTGRE_HOST }}
  DATA_NAME: nanoDb
  DATA_USER: api-data-postgre-user
  DATA_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_POSTGRE_NANO_DB_PASSWORD || secrets.STAGING_POSTGRE_NANO_DB_PASSWORD }}
  DATA_ADMIN_USER: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_POSTGRE_ADMIN_USER || secrets.STAGING_POSTGRE_ADMIN_USER }}
  DATA_ADMIN_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_POSTGRE_ADMIN_PASSWORD || secrets.STAGING_POSTGRE_ADMIN_PASSWORD }}
  DATA_CONNECTIONSTRING: Host=${{ env.DATA_HOST }};Port=${{ vars.DATA_POSTGRE_PORT }};Database=${{ env.DATA_NAME }};Username=${{ env.DATA_USER }};Password=${{ env.DATA_PASSWORD }};SSL Mode=Prefer;Trust Server Certificate=true
  DATA_MIGRATION_CONNECTIONSTRING: Host=${{ env.DATA_HOST }};Port=${{ vars.DATA_POSTGRE_PORT }};Database=${{ env.DATA_NAME }};Username=${{ env.DATA_ADMIN_USER }};Password=${{ env.DATA_ADMIN_PASSWORD }};SSL Mode=Prefer;Trust Server Certificate=true
```

Additionally, this step has been added to ensure database migrations are applied, and the application database user has been created before the application is deployed.  

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
         
    sudo apt-get update
    sudo apt-get install -y postgresql-client

    $userExists = psql "host=$env:DATA_HOST port=$env:DATA_POSTGRE_PORT user=$env:DATA_ADMIN_USER password=$env:DATA_ADMIN_PASSWORD dbname=postgres" `
        -tAc "SELECT 1 FROM pg_roles WHERE rolname='$env:DATA_USER';"

    if ($userExists -ne "1")
    {
    psql "host=$env:DATA_HOST port=$env:DATA_POSTGRE_PORT user=$env:DATA_ADMIN_USER password=$env:DATA_ADMIN_PASSWORD dbname=postgres" `
        -c "CREATE ROLE $env:DATA_USER WITH LOGIN PASSWORD '$env:DATA_PASSWORD';"
    }

    $userDbExists = psql "host=$env:DATA_HOST port=$env:DATA_POSTGRE_PORT user=$env:DATA_ADMIN_USER password=$env:DATA_ADMIN_PASSWORD dbname=$env:DATA_NAME" `
        -tAc "SELECT 1 FROM pg_roles WHERE rolname='$env:DATA_USER';"

    if ($userDbExists -ne "1")
    {
        psql "host=$env:DATA_HOST port=$env:DATA_POSTGRE_PORT user=$env:DATA_ADMIN_USER password=$env:DATA_ADMIN_PASSWORD dbname=$env:DATA_NAME" `
            -c "GRANT CONNECT ON DATABASE $env:DATA_NAME TO $env:DATA_USER;"

        psql "host=$env:DATA_HOST port=$env:DATA_POSTGRE_PORT user=$env:DATA_ADMIN_USER password=$env:DATA_ADMIN_PASSWORD dbname=$env:DATA_NAME" `
            -c "GRANT USAGE ON SCHEMA public TO $env:DATA_USER;"

        psql "host=$env:DATA_HOST port=$env:DATA_POSTGRE_PORT user=$env:DATA_ADMIN_USER password=$env:DATA_ADMIN_PASSWORD dbname=$env:DATA_NAME" `
            -c "GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO $env:DATA_USER;"

       psql "host=$env:DATA_HOST port=$env:DATA_POSTGRE_PORT user=$env:DATA_ADMIN_USER password=$env:DATA_ADMIN_PASSWORD dbname=$env:DATA_NAME" `
           -c "ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO $env:DATA_USER;"
    }
```

Last, the application connectionstring must be added in a secret in Kuberntes. The `Kubernetes Deploy` step has been updated with the following.  

```yaml
sudo kubectl create secret generic $env:SERVICE_NAME-data-secret ` --from-literal=data-connectionstring=$env:DATA_CONNECTIONSTRING --save-config --dry-run=client -o yaml | sudo kubectl apply -f -;
if ($LastExitCode -ne 0)
{ 
    throw "error";
};
```
