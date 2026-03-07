# Api.Data.MySql

> _Nano API application with mysql data._  
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
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a test controller that inherits from 
the Nano `BaseEntityControllerr<TEntity, TCriteria>`. The available entity endpoints are inherited, and no additional endpoints has been added.  

This example demonstrates how various parts of Nano data work together. All data configuration and registration have been completed, and classes have been implemented 
for the data parts, including [Data Models](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-models), 
[Data Mappings](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-mappings), and the 
[Data Context](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#data-context).  

Additionally, the example shows how Nano [Data Repository](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#repositories) works along with the corresponding 
entity controllers. For more information on controllers and how they are connected with entity models, 
see [Nano Entity Controllers](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#controllers).

A data health check is configured to target the database.  
Open the health-check UI here to view the database health status: **[http://localhost:8080/healthz-ui](http://localhost:8080/healthz-ui)**.  

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#health-checks)**.

Also, API documentation has been configured, in order to easier see which endpoints are available. It can be accessed 
here: **[http://localhost:8080/docs](http://localhost:8080/docs)**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

The following endpoint is available for testing.  

| Endpoint                                                | Method        | Description                                                                  |
| ------------------------------------------------------- | ------------- | ---------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/create`             | POST          | Creates a single model instance.                                             |
| `http://localhost:8080/api/examples/create/get`         | POST          | Creates a single model instance and retrieves it with included navigations.  |
| `http://localhost:8080/api/examples/create/many`        | POST          | Creates multiple model instances.                                            |
| `http://localhost:8080/api/examples/create/many/bulk`   | POST          | Creates multiple model instances in bulk.                                    |
| `http://localhost:8080/api/examples/{id}/details`       | GET           | Gets a single entity by its identifier.                                      |
| `http://localhost:8080/api/examples/details/many`       | GET, POST     | Gets multiple entities by their identifiers.                                 |
| `http://localhost:8080/api/examples/index`              | GET, POST     | Gets all entities matching the specified query.                              |
| `http://localhost:8080/api/examples/query`              | GET, POST     | Queries entities matching the specified criteria.                            |
| `http://localhost:8080/api/examples/query/count`        | GET, POST     | Gets the total count of entities matching the specified criteria.            |
| `http://localhost:8080/api/examples/query/first`        | GET, POST     | Retrieves the first entity matching the specified criteria.                  |
| `http://localhost:8080/api/examples/edit`               | PUT, POST     | Edits a single model instance.                                               |
| `http://localhost:8080/api/examples/edit/get`           | PUT, POST     | Edits a single model instance and retrieves it with included navigations.    |
| `http://localhost:8080/api/examples/edit/many`          | PUT, POST     | Edits multiple model instances.                                              |
| `http://localhost:8080/api/examples/edit/many/bulk`     | PUT, POST     | Edits multiple model instances in bulk.                                      |
| `http://localhost:8080/api/examples/edit/query`         | PUT, POST     | Edits entities that match the specified criteria.                            |
| `http://localhost:8080/api/examples/edit/query/bulk`    | PUT, POST     | Edits entities that match the specified criteria in bulk.                    |
| `http://localhost:8080/api/examples/{id}/delete`        | POST, DELETE  | Deletes a single entity by its identifier.                                   |
| `http://localhost:8080/api/examples/delete/many`        | POST, DELETE  | Deletes multiple entities by their identifiers.                              |
| `http://localhost:8080/api/examples/delete/many/bulk`   | POST, DELETE  | Deletes multiple entities by their identifiers in bulk.                      |
| `http://localhost:8080/api/examples/delete/query`       | POST, DELETE  | Deletes entities matching the specified criteria.                            |
| `http://localhost:8080/api/examples/delete/query/bulk`  | POST, DELETE  | Deletes entities matching the specified criteria in bulk.                    |

> 📖 Learn more about **[Nano Data MySql](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.MySql)**.

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
  "UseCreateDatabase": false,
  "UseMigrateDatabase": false,
  "UseSoftDeletetion": false,
  "UseSensitiveDataLogging": false,
  "UseAudit": false,
  "QuerySplittingBehavior": "SingleQuery",
  "DefaultCollation": null,
  "ConnectionString": null,
  "Repository": {
    "UseAutoSave": false,
    "QueryIncludeDepth": 4
  },
  "Cache": null,
  "Identity": null,
  "ConnectionPool": null,
  "HealthCheck": null
}
```
...and `appsettings.Development.json`

```json
"Data": {
  "UseMigrateDatabase": true,
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
Added the `rabbitmq` secret for password to the `deployment.yaml`.  

```json
spec:
  template:
    spec:
      containers:
        env:
        - name: Data__ConnectionString
          valueFrom:
            secretKeyRef:
              name: %SERVICE_NAME%-secret
              key: data-connectionstring
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  MYSQL_DATABASE_NAME: nanoDb
  MYSQL_DATABASE_USER: api-data-mysql-user
  MYSQL_HOST: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_MYSQL_HOST || secrets.STAGING_MYSQL_HOST }}
  MYSQL_SERVICE_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_MYSQL_NANO_DB_PASSWORD || secrets.STAGING_MYSQL_NANO_DB_PASSWORD }}
  MYSQL_ADMIN_USER: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_MYSQL_ADMIN_USER || secrets.STAGING_MYSQL_ADMIN_USER }}
  MYSQL_ADMIN_PASSWORD: ${{ github.ref == 'refs/heads/master' && secrets.PRODUCTION_MYSQL_ADMIN_PASSWORD || secrets.STAGING_MYSQL_ADMIN_PASSWORD }}
  MYSQL_CONNECTIONSTRING: Server=${{ env.MYSQL_HOST }};Port=${{ vars.MYSQL_PORT }};Database=${{ env.MYSQL_DATABASE_NAME }};Uid=${{ env.MYSQL_DATABASE_USER }};Pwd=${{ env.MYSQL_SERVICE_PASSWORD }};SslMode=Preferred;
  MYSQL_MIGRATION_CONNECTIONSTRING: Server=${{ env.MYSQL_HOST }};Port=${{ vars.MYSQL_PORT }};Database=${{ env.MYSQL_DATABASE_NAME }};Uid=${{ env.MYSQL_ADMIN_USER }};Pwd=${{ env.MYSQL_ADMIN_PASSWORD }};SslMode=Preferred;
```

Additionally, this step has been added to ensure database migrations are applied, and the application database user has been created before the application is deployed.  

```yaml
- name: Database Migration
  shell: pwsh
  run: |
    dotnet ef database update `
      --no-build `
      --startup-project $env:APP_NAME `
      --connection "$env:MYSQL_MIGRATION_CONNECTIONSTRING" `;

    if ($LastExitCode -ne 0)
    { 
        throw "error";
    };
         
    sudo apt-get update
    sudo apt-get install -y mysql-client

    $userExists = mysql --connect-expired-password --batch -e "SELECT EXISTS(SELECT 1 FROM mysql.user WHERE user = '$env:MYSQL_DATABASE_USER');" $env:MYSQL_MIGRATION_CONNECTIONSTRING;

    if ($userExists -eq 0) 
    {
        mysql --connect-expired-password -e " `
            CREATE USER '$env:MYSQL_DATABASE_USER'@'%' IDENTIFIED BY '$env:MYSQL_PASSWORD'; `
            GRANT SELECT, INSERT, UPDATE, DELETE ON $database.* TO '$env:MYSQL_DATABASE_USER'@'%'; `
            FLUSH PRIVILEGES;" $env:MYSQL_MIGRATION_CONNECTIONSTRING
    }
```

Last, the application connectionstring must be added in a secret in Kuberntes. The `Kubernetes Deploy` has been updated with the following.  

```yaml
sudo kubectl create secret generic $env:SERVICE_NAME-secret ` --from-literal=data-connectionstring=$env:MYSQL_CONNECTIONSTRING --save-config --dry-run=client -o yaml | sudo kubectl apply -f -;
if ($LastExitCode -ne 0)
{ 
    throw "error";
};
```
