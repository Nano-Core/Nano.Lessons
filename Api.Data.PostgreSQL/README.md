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
for the data parts, including **[Data Models](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data/README.md#data-models)**, **[Data Mappings](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data/README.md#data-mappings)**, 
and the **[Data Context](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data/README.md#data-context)**.  

Additionally, the example shows how Nano [Data Repository](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data/README.md#repositories) works along with the corresponding 
entity controllers. For more information on controllers and how they are connected with entity models, see **[Nano Entity Controllers](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#controllers)**.

A data health check is configured to target the database.  
Open **[http://localhost:8080/healthz](http://localhost:8080/healthz)** to view the health-check status in the JSON response.

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#health-checks)**.

Also, API documentation has been configured, in order to easier see which endpoints are available. It can be accessed 
here: **[http://localhost:8080/docs](http://localhost:8080/docs)**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#documentation)**.  

Additionally, controllers have been implemented to demonstrate controllers for creatable, updatable, creatable-and-updatable, and deletable entities. When viewing 
the API documentation, observe how the available endpoints differ depending on the capabilities supported by each controller.  

> 📖 Learn more about **[Nano.Data.PostgreSQL](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.PostgreSQL/README.md#nanodatamysql)**.

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
    "UseAutoSave": true,
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
Added the `auth-sql-secret.yaml` for the connectionstring to the `deployment.yaml`.  

```json
spec:
  template:
    spec:
      containers:
        env:
        - name: Data__ConnectionString
          valueFrom:
            secretKeyRef:
              name: %SERVICE_NAME%-sql-auth-secret
              key: data-connectionstring
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  DOTNET_EF_TOOLS_VERSION: "10.0"
  AZURE_GROUP_DATABASE : ${{ vars.AZURE_RESOURCE_GROUP_DATABASE }}
  SQL_NAME: nanoDb
  SQL_USER: api-data-postgres-user
  SQL_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_SQL_NANO_DB_PASSWORD || secrets.STAGING_SQL_NANO_DB_PASSWORD }}
  SQL_ADMIN_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_SQL_ADMIN_PASSWORD || secrets.STAGING_SQL_ADMIN_PASSWORD }}
```

Additionally, this step has been added to ensure database migrations are applied, and the application database user has been created before the application is deployed.  

```yaml
- name: Database Migration & User
  shell: pwsh
  run: |
    $env:SQL_HOST = az postgres flexible-server list -g $env:AZURE_GROUP_DATABASE --query "[0].fullyQualifiedDomainName" -o tsv;
    $env:SQL_PORT = "5432";
    $env:SQL_ADMIN_USER = az postgres flexible-server list -g $env:AZURE_GROUP_DATABASE --query "[0].username" -o tsv;
    $env:SQL_MIGRATION_CONNECTIONSTRING = "Host=$env:SQL_HOST;Port=$env:SQL_PORT;Database=$env:SQL_NAME;Username=$env:SQL_ADMIN_USER;Password=$env:SQL_ADMIN_PASSWORD;SSL Mode=Prefer;Trust Server Certificate=true";

    $env:DATA__CONNECTIONSTRING = $env:SQL_MIGRATION_CONNECTIONSTRING;

    & "/opt/ef-tools/$env:DOTNET_EF_TOOLS_VERSION/dotnet-ef" database update `
    --no-build `
    --configuration Release `
    --startup-project $env:APP_NAME `
    -- `
    --environment $env:ASPNETCORE_ENVIRONMENT;

    if ($LastExitCode -ne 0)
    { 
        throw "error";
    };

    $userExists = psql "$env:SQL_MIGRATION_CONNECTIONSTRING" `
        -tAc "SELECT 1 FROM pg_roles WHERE rolname='$env:SQL_USER';"

    if ($userExists -ne "1")
    {
        psql "$env:SQL_MIGRATION_CONNECTIONSTRING" `
            -c "CREATE ROLE $env:SQL_USER WITH LOGIN PASSWORD '$env:SQL_PASSWORD';"
    }

    $userDbExists = psql "$env:SQL_MIGRATION_CONNECTIONSTRING" `
        -tAc "SELECT 1 FROM pg_roles WHERE rolname='$env:SQL_USER';"

    if ($userDbExists -ne "1")
    {
        psql "$env:SQL_MIGRATION_CONNECTIONSTRING" `
            -c "GRANT CONNECT ON DATABASE $env:SQL_NAME TO $env:SQL_USER;"

        psql "$env:SQL_MIGRATION_CONNECTIONSTRING" `
            -c "GRANT USAGE ON SCHEMA public TO $env:SQL_USER;"

        psql "$env:SQL_MIGRATION_CONNECTIONSTRING" `
            -c "GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO $env:SQL_USER;"

        psql "$env:SQL_MIGRATION_CONNECTIONSTRING" `
            -c "ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO $env:SQL_USER;"
    }

    echo "SQL_HOST=$env:SQL_HOST" >> $env:GITHUB_ENV;
    echo "SQL_PORT=$env:SQL_PORT" >> $env:GITHUB_ENV;
```

Last, before applying the new Kubernetes templates, these environmental variables must be set.

```powershell
$env:SQL_CONNECTIONSTRING = "Host=$env:SQL_HOST;Port=$env:SQL_PORT;Database=$env:SQL_NAME;Username=$env:SQL_USER;Password=$env:SQL_PASSWORD;SSL Mode=Require;Trust Server Certificate=true";
```

Finally, apply the templates.
