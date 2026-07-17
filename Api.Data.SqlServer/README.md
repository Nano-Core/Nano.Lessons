# Api.Data.SqlServer

> _Nano API application with sql server data._  
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

Additionally, the example shows how Nano **[Data Repository](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data/README.md#repositories)** works along with the corresponding 
entity controllers. For more information on controllers and how they are connected with entity models, see **[Nano Entity Controllers](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#controllers)**.

A data health check is configured to target the database.  
Open **[http://localhost:8080/healthz](http://localhost:8080/healthz)** to view the health-check status in the JSON response.

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#health-checks)**.

Also, API documentation has been configured, in order to easier see which endpoints are available. It can be accessed 
here: **[http://localhost:8080/docs](http://localhost:8080/docs)**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#documentation)**.  

Additionally, controllers have been implemented to demonstrate controllers for creatable, updatable, creatable-and-updatable, and deletable entities. When viewing 
the API documentation, observe how the available endpoints differ depending on the capabilities supported by each controller.  

> 📖 Learn more about **[Nano.Data.SqlServer](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.SqlServer/README.md#nanodatamysql)**.

## Registration
The following data provider has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(services =>
{
    services
        .AddNanoData<SqlServerProvider, SqlServerDbContext>();
})
...
```

Also, an initial migration has been added to the project.

```powershell
dotnet ef migrations add Initial --project Api.Data.SqlServer
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
  "ConnectionString": "Server=host.docker.internal,1433;Database=nanoDb;User Id=sa;Password=myPassword_123;Encrypt=False;"
}
```

## Docker Compose
Added Sql Server as a service dependency in `docker-compose.yml`.  

```yaml
services:
  api.data.sqlserver:
    depends_on:
      - database

  database:
    image: mcr.microsoft.com/mssql/server:2022-latest
    ports:
      - 1433:1433
    networks:
      - network
    environment:
      SA_PASSWORD: myPassword_123
      ACCEPT_EULA: Y
      MSSQL_PID: Developer
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
  SQL_USER: api-data-sqlserver-user
  SQL_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_SQL_NANO_DB_PASSWORD || secrets.STAGING_SQL_NANO_DB_PASSWORD }}
  SQL_ADMIN_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_SQL_ADMIN_PASSWORD || secrets.STAGING_SQL_ADMIN_PASSWORD }}
```

Additionally, this step has been added to ensure database migrations are applied, and the application database user has been created before the application is deployed.  

```yaml
- name: Database Migration & User
  shell: pwsh
  run: |
    $env:SQL_HOST = az sql server list -g $env:AZURE_GROUP_DATABASE --query "[0].fullyQualifiedDomainName" -o tsv;
    $env:SQL_PORT = "1433"
    $env:SQL_ADMIN_USER = az sql server list -g $env:AZURE_GROUP_DATABASE --query "[0].administratorLogin" -o tsv;

    $env:DATA__CONNECTIONSTRING = "Server=$env:SQL_HOST,$env:SQL_PORT;Database=$env:SQL_NAME;User Id=$env:SQL_ADMIN_USER;Password=$env:SQL_ADMIN_PASSWORD;Encrypt=True;TrustServerCertificate=True;";

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
          
    apt-get update
    apt-get install -y mssql-tools unixodbc-dev

    $loginExists = sqlcmd `
    -S "$env:SQL_HOST,$env:SQL_PORT" `
    -U $env:SQL_ADMIN_USER `
    -P $env:SQL_ADMIN_PASSWORD `
    -d main `
    -h -1 `
    -Q "SET NOCOUNT ON; SELECT COUNT(*) FROM sys.server_principals WHERE name = '$env:SQL_USER';"

    if ($loginExists -eq 0)
    {
        sqlcmd `
        -S "$env:SQL_HOST,$env:SQL_PORT" `
        -U $env:SQL_ADMIN_USER `
        -P $env:SQL_ADMIN_PASSWORD `
        -d main `
        -Q "CREATE LOGIN [$env:SQL_USER] WITH PASSWORD = '$env:SQL_PASSWORD';"
    };

    $userExists = sqlcmd `
    -S "$env:SQL_HOST,$env:SQL_PORT" `
    -U $env:SQL_ADMIN_USER `
    -P $env:SQL_ADMIN_PASSWORD `
    -d $env:SQL_NAME `
    -h -1 `
    -Q "SET NOCOUNT ON; SELECT COUNT(*) FROM sys.database_principals WHERE name = '$env:SQL_USER';"

    if ($userExists -eq 0)
    {
        sqlcmd `
        -S "$env:SQL_HOST,$env:SQL_PORT" `
        -U $env:SQL_ADMIN_USER `
        -P $env:SQL_ADMIN_PASSWORD `
        -d $env:SQL_NAME `
        -Q "CREATE USER [$env:SQL_USER] FOR LOGIN [$env:SQL_USER];
            ALTER ROLE db_datareader ADD MEMBER [$env:SQL_USER];
            ALTER ROLE db_datawriter ADD MEMBER [$env:SQL_USER];"
    };

    echo "SQL_HOST=$env:SQL_HOST" >> $env:GITHUB_ENV;
    echo "SQL_PORT=$env:SQL_PORT" >> $env:GITHUB_ENV;
```

Last, before applying the new Kubernetes templates, these environmental variables must be set.

```powershell
$env:SQL_CONNECTIONSTRING = "Server=$env:SQL_HOST,$env:SQL_PORT;Database=$env:SQL_NAME;User Id=$env:SQL_USER;Password=$env:SQL_PASSWORD;Encrypt=True;TrustServerCertificate=True;";
```

Finally, the templates can be applied.
