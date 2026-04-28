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
              name: %SERVICE_NAME%-data-secret
              key: data-connectionstring
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  DATA_HOST: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_MYSQL_HOST || secrets.STAGING_MYSQL_HOST }}
  DATA_NAME: nanoDb
  DATA_USER: api-data-mysql-user
  DATA_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_MYSQL_NANO_DB_PASSWORD || secrets.STAGING_MYSQL_NANO_DB_PASSWORD }}
  DATA_ADMIN_USER: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_MYSQL_ADMIN_USER || secrets.STAGING_MYSQL_ADMIN_USER }}
  DATA_ADMIN_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_MYSQL_ADMIN_PASSWORD || secrets.STAGING_MYSQL_ADMIN_PASSWORD }}
  DATA_CONNECTIONSTRING: Server=${{ env.DATA_HOST }};Port=${{ vars.DATA_MYSQL_PORT }};Database=${{ env.DATA_NAME }};Uid=${{ env.DATA_USER }};Pwd=${{ env.DATA_PASSWORD }};SslMode=Preferred;
  DATA_MIGRATION_CONNECTIONSTRING: Server=${{ env.DATA_HOST }};Port=${{ vars.DATA_MYSQL_PORT }};Database=${{ env.DATA_NAME }};Uid=${{ env.DATA_ADMIN_USER }};Pwd=${{ env.DATA_ADMIN_PASSWORD }};SslMode=Preferred;
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
    sudo apt-get install -y mysql-client

    $userExists = mysql --connect-expired-password --batch -e "SELECT EXISTS(SELECT 1 FROM mysql.user WHERE user = '$env:DATA_USER');" $env:DATA_MIGRATION_CONNECTIONSTRING;

    if ($userExists -eq 0) 
    {
        mysql --connect-expired-password -e " `
            CREATE USER '$env:DATA_USER'@'%' IDENTIFIED BY '$env:DATA_PASSWORD'; `
            GRANT SELECT, INSERT, UPDATE, DELETE ON $database.* TO '$env:DATA_USER'@'%'; `
            FLUSH PRIVILEGES;" $env:DATA_MIGRATION_CONNECTIONSTRING
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
