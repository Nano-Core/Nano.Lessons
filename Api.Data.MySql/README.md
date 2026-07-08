# Api.Data.MySql

> _Nano API application with mysql data._  
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

> 📖 Learn more about **[Nano.Data.MySql](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.MySql/README.md#nanodatamysql)**.

## Registration
The following data provider has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(services =>
{
    services
        .AddNanoData<MySqlProvider, MySqlDbContext>();
})
...
```

Also, an initial migration has been added to the project.

```powershell
dotnet ef migrations add Initial --project Api.Data.MySql
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

...and `appsettings.Development.json`.  

```json
"Data": {
  "StartupAction": "Migrate",
  "ConnectionString": "Server=host.docker.internal;Database=nanoDb;Uid=sa;Pwd=myPassword_123"
}
```

## Docker Compose
Added MySql as a service dependency in `docker-compose.yml`.  

```yaml
services:
  api.data.mysql:
    depends_on:
      - database

  database:
    image: mysql/mysql-server:latest
    ports:
      - 3306:3306
    networks:
      - network
    environment:
      MYSQL_USER: sa
      MYSQL_PASSWORD: myPassword_123
      MYSQL_ROOT_PASSWORD: myPassword_123
      MYSQL_DATABASE: nanoDb
      MYSQL_ROOT_HOST: '%'
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
              name: %SERVICE_NAME%-sql-auth-secret
              key: data-connectionstring
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  SQL_NAME: nanoDb
  SQL_USER: api-data-mysql-user
  SQL_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_SQL_NANO_DB_PASSWORD || secrets.STAGING_SQL_NANO_DB_PASSWORD }}
  SQL_ADMIN_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_SQL_ADMIN_PASSWORD || secrets.STAGING_SQL_ADMIN_PASSWORD }}
```

Additionally, this step has been added to ensure database migrations are applied, and the application database user has been created before the application is deployed.  

```yaml
- name: Database Migration & User
  shell: pwsh
  run: |
    $env:SQL_HOST = az mysql flexible-server list -g $env:AZURE_GROUP_DATABASE --query [0].fullyQualifiedDomainName -o tsv;
    $env:SQL_PORT = az mysql flexible-server list -g $env:AZURE_GROUP_DATABASE --query [0].databasePort -o tsv;
    $env:SQL_ADMIN_USER = az mysql flexible-server list -g $env:AZURE_GROUP_DATABASE --query [0].administratorLogin -o tsv;

    $env:DATA__CONNECTIONSTRING = "Server=$env:SQL_HOST;Port=$env:SQL_PORT;Database=$env:SQL_NAME;Uid=$env:SQL_ADMIN_USER;Pwd=$env:SQL_ADMIN_PASSWORD;SslMode=Required";

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
          
    $env:MYSQL_PWD = $env:SQL_ADMIN_PASSWORD

    $userExists = mysql `
        --host $env:SQL_HOST `
        --port $env:SQL_PORT `
        --user $env:SQL_ADMIN_USER `
        --ssl-mode=REQUIRED `
        -e "SELECT EXISTS(SELECT 1 FROM mysql.user WHERE user = '$env:SQL_USER');";

    if ($userExists -eq 0) 
    {
        mysql `
            --host $env:SQL_HOST `
            --port $env:SQL_PORT `
            --user $env:SQL_ADMIN_USER `
            --ssl-mode=REQUIRED `
            -e "CREATE USER '$env:SQL_USER'@'%' IDENTIFIED BY '$env:SQL_PASSWORD'; GRANT SELECT, INSERT, UPDATE, DELETE ON $env:SQL_NAME.* TO '$env:SQL_USER'@'%'; FLUSH PRIVILEGES;";

        if ($LastExitCode -ne 0)
        { 
            throw "error";
        };
    }

    echo "SQL_HOST=$env:SQL_HOST" >> $env:GITHUB_ENV;
    echo "SQL_PORT=$env:SQL_PORT" >> $env:GITHUB_ENV;
```

Last, an additional template has been added to the deployment for storing the application connectionstring in a Kuberntes secret.  
