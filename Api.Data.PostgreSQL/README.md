# Api.Data.PostgreSQL

> _Nano API application with postgre sql data._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api._Blank)** and adds a test controller that inherits from 
the Nano `BaseEntityControllerr<TEntity, TCriteria>`. The available entity endpoints are inherited, and no additional endpoints has been added.  

This example demonstrates how various parts of Nano data work together. All data configuration and registration have been completed, and classes have been implemented 
for the data parts, including **[Data Models](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data/README.md#data-models)**, **[Data Mappings](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data/README.md#data-mappings)**, 
and the **[Data Context](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data/README.md#data-context)**.  

Additionally, the example shows how Nano [Data Repository](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data/README.md#repositories) works along with the corresponding 
entity controllers. For more information on controllers and how they are connected with entity models, see **[Nano Entity Controllers](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#controllers)**.

A data health check is configured to target the database.  
Open **[http://localhost:8080/healthz](http://localhost:8080/healthz)** to view the health-check status in the JSON response.

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#health-checks)**.

Also, API documentation has been configured, in order to easier see which endpoints are available. It can be accessed 
here: **[http://localhost:8080/docs](http://localhost:8080/docs)**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api/README.md#documentation)**.  

Additionally, controllers have been implemented to demonstrate controllers for creatable, updatable, creatable-and-updatable, and deletable entities. When viewing 
the API documentation, observe how the available endpoints differ depending on the capabilities supported by each controller.  

> 📖 Learn more about **[Nano.Data.PostgreSQL](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data.PostgreSQL/README.md#nanodatapostgresqll)**.

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
  "AuthenticationType": "Credentials",
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

Also added the following variable to the `configmap.yaml`.

```yaml
data:
  Data__AuthenticationType: %SQL_AUTH_TYPE%
```

## GitHub Actions
Add the following environment variables to the `buid-and-deply.yml`.  

```yaml
env:
  DOTNET_EF_TOOLS_VERSION: "10.0"
  AZURE_GROUP_DATABASE : ${{ vars.AZURE_RESOURCE_GROUP_DATABASE }}
  SQL_AUTH_TYPE: Azure
  SQL_NAME: nanoDb
```

Additionally, these steps has been added to ensure database migrations are applied and the application database user is created, using the application's managed identity, before the 
application is deployed.

```yaml
- name: Managed Identity
  shell: pwsh
  run: |
    $env:IDENTITY_NAME = $env:SERVICE_NAME + "-identity";
    $env:IDENTITY_PRINCIPAL_ID = az identity show -g $env:AZURE_GROUP_KUBERNETES -n $env:IDENTITY_NAME --query principalId -o tsv;
    $env:KUBERNETES_ISSUER_URL = az aks list -g $env:AZURE_GROUP_KUBERNETES --query [0].['oidcIssuerProfile.issuerUrl'] -o tsv;

    if (-not $env:IDENTITY_PRINCIPAL_ID)
    {
        az identity create `
            -g $env:AZURE_GROUP_KUBERNETES `
            -n $env:IDENTITY_NAME;

        if ($LastExitCode -ne 0)
        {
            throw "error";
        };

        $env:IDENTITY_PRINCIPAL_ID = az identity show -g $env:AZURE_GROUP_KUBERNETES -n $env:IDENTITY_NAME --query principalId -o tsv;
    }
          
    $env:IDENTITY_CLIENT_ID = az identity show -g $env:AZURE_GROUP_KUBERNETES -n $env:IDENTITY_NAME --query clientId -o tsv;

    az identity federated-credential create `
        --name $env:SERVICE_NAME-credentials `
        --resource-group $env:AZURE_GROUP_KUBERNETES `
        --identity-name $env:IDENTITY_NAME `
        --issuer $env:KUBERNETES_ISSUER_URL `
        --subject "system:serviceaccount:${env:KUBERNETES_NAMESPACE}:${env:SERVICE_NAME}-service-account" `
        --audience api://AzureADTokenExchange;

    if ($LastExitCode -ne 0)
    {
        throw "error";
    };
          
    echo "IDENTITY_NAME=$env:IDENTITY_NAME" >> $env:GITHUB_ENV;
    echo "IDENTITY_CLIENT_ID=$env:IDENTITY_CLIENT_ID" >> $env:GITHUB_ENV; 
    echo "IDENTITY_PRINCIPAL_ID=$env:IDENTITY_PRINCIPAL_ID" >> $env:GITHUB_ENV; 

- name: PostgreSQL Database Migration
  shell: pwsh
  run: |
    $env:SQL_HOST = az postgres flexible-server list -g $env:AZURE_GROUP_DATABASE --query [0].fullyQualifiedDomainName -o tsv;
    $env:SQL_PORT = 5432;
    $env:SQL_SERVER = az postgres flexible-server list -g $env:AZURE_GROUP_DATABASE --query [0].name -o tsv;
    $env:SQL_USER = az postgres flexible-server ad-admin list -g $env:AZURE_GROUP_DATABASE -s $env:SQL_SERVER --query "[0].principalName" -o tsv;
    $env:SQL_TOKEN = az account get-access-token --resource-type oss-rdbms --query accessToken -o tsv;

    $env:DATA__CONNECTIONSTRING = "Host=$env:SQL_HOST;Port=$env:SQL_PORT;Database=$env:SQL_NAME;Username=$env:SQL_USER;Password=$env:SQL_TOKEN;SSL Mode=Require;Trust Server Certificate=true";

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

    $env:PRINCIPAL_SQL_PATH = Join-Path $env:USERPROFILE "app-database-principal.sql";
    $env:GRANTS_SQL_PATH = Join-Path $env:USERPROFILE "app-database-grants.sql";

    $principalSql = @"
      DO `$`$
      BEGIN
          IF NOT EXISTS (SELECT 1 FROM pg_roles WHERE rolname = '$env:IDENTITY_NAME') THEN
          PERFORM pgaadauth_create_principal('$env:IDENTITY_NAME', false, false);
          END IF;
      END
      `$`$;
    "@;

    $principalSql | Set-Content $env:PRINCIPAL_SQL_PATH;

    az postgres flexible-server execute `
        -n $env:SQL_SERVER `
        -u $env:SQL_USER `
        -p $env:SQL_TOKEN `
        -d postgres `
        --file-path $env:PRINCIPAL_SQL_PATH;

    if ($LastExitCode -ne 0)
    {
        throw "error";
    };

    $grantsSql = @"
      GRANT CONNECT ON DATABASE $env:SQL_NAME TO "$env:IDENTITY_NAME";
      GRANT USAGE ON SCHEMA public TO "$env:IDENTITY_NAME";
      GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO "$env:IDENTITY_NAME";
      ALTER DEFAULT PRIVILEGES IN SCHEMA public GRANT SELECT, INSERT, UPDATE, DELETE ON TABLES TO "$env:IDENTITY_NAME";
    "@;

    $grantsSql | Set-Content $env:GRANTS_SQL_PATH;

    az postgres flexible-server execute `
        -n $env:SQL_SERVER `
        -u $env:SQL_USER `
        -p $env:SQL_TOKEN `
        -d $env:SQL_NAME `
        --file-path $env:GRANTS_SQL_PATH;

    if ($LastExitCode -ne 0)
    {
        throw "error";
    };

    $env:SQL_CONNECTIONSTRING = "Host=$env:SQL_HOST;Port=$env:SQL_PORT;Database=$env:SQL_NAME;Username=$env:IDENTITY_NAME;SSL Mode=Require;Trust Server Certificate=true";
    echo "SQL_CONNECTIONSTRING=$env:SQL_CONNECTIONSTRING" >> $env:GITHUB_ENV;
```

Finally, apply the templates.
