# Api.HealthChecks

> _Nano API application with health checks._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [GitHub Actions](#gitHub-actions)

## Summary
This application builds on **[Api.Hosting.Https](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.Hosting.Https)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This example illustrates the use of Nano API health-checks.  

Open [http://localhost:8080/healthz](http://localhost:8080/healthz) to view the startup health-check JSON report.  

The following endpoints are available for testing.  

| Endpoint                                          | Description                                            |
| ------------------------------------------------- | ------------------------------------------------------ |
| `http://localhost:8080/api/examples/health-check` | Returns a `200 OK` response with health-check status.  |

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.App.Api#health-checks)**.

## Configuration
There is no configuration for HealtCheck, the section has just been added to enable the feature.  

```json
"App": {
  "HealthCheck": {
  }
}
```

## GitHub Actions
Optionally, you can configure an availability check in Azure using Application Insights to continuously monitor your application's health and responsiveness.  

> ⚠️ This requires the application to be exposed publicly from Kubernetes via an `httproute` configuration.

First, add the following environment variables.

```yaml
env:
  AZURE_GROUP_LOGS: ${{ vars.AZURE_RESOURCE_GROUP_LOGS }}
```

And then the Availability Check step to the end of the pipeline.  

```yaml
- name: Add Availability Check
  shell: pwsh
  run: |
    $env:AZURE_LOCATION = az monitor log-analytics workspace list -g $env:AZURE_GROUP_LOGS --query [0].location -o tsv;
    $env:APPLICATION_INSIGHT_ID = az monitor app-insights component show -g $env:AZURE_GROUP_LOGS --query [0].id -o tsv;
    $env:HIDDEN_LINK = 'hidden-link:' + $env:APPLICATION_INSIGHT_ID + '=Resource';

    $zoneNames = az network dns zone list -g $env:AZURE_GROUP_DNS --query "[].name" -o json | ConvertFrom-Json

    foreach ($zoneName in $zoneNames)
    {
        $env:WEB_TEST_NAME = $env:SERVICE_NAME + '-availability-' + $env:ASPNETCORE_ENVIRONMENT.ToLower() + '-' + $env:SUB_DOMAIN_NAME  + '-' + ($zoneName.TrimEnd('.') -replace '\.', '-')

        az monitor app-insights web-test show -g $env:AZURE_GROUP_LOGS -n $env:WEB_TEST_NAME --query id -o tsv 2>$null

        if ($LastExitCode -ne 0)
        {
            az monitor app-insights web-test create `
                -n $env:WEB_TEST_NAME `
                --defined-web-test-name $env:WEB_TEST_NAME `
                -g $env:AZURE_GROUP_LOGS `
                -l $env:AZURE_LOCATION `
                --kind ping `
                --web-test-kind standard `
                --frequency 300 `
                --enabled true `
                --retry-enabled true `
                --ssl-check true `
                --ssl-lifetime-check 30 `
                --http-verb GET `
                --request-url https://$env:SUB_DOMAIN_NAME.$zoneName/healthz `
                --expected-status-code 200 `
                --content-validation content-match='"status":"unhealthy"' ignore-case=true pass-if-text-found=false `
                --tags $env:HIDDEN_LINK `
                --locations Id='us-ca-sjc-azr' `
                --locations Id='us-va-ash-azr' `
                --locations Id='emea-gb-db3-azr' `
                --locations Id='emea-nl-ams-azr' `
                --locations Id='apac-hk-hkn-azr';

            if ($LastExitCode -ne 0)
            {
                throw "error";
            }
        }

        $env:WEB_TEST_ALERT_NAME = $env:WEB_TEST_NAME + "-alert";

        az resource show -g $env:AZURE_GROUP_LOGS -n $env:WEB_TEST_ALERT_NAME --query id -o tsv 2>$null;

        if ($LastExitCode -ne 0)
        {
            $env:WEB_TEST_ID = az monitor app-insights web-test show -g $env:AZURE_GROUP_LOGS -n $env:WEB_TEST_NAME --query id -o tsv;
            $env:ACTION_GROUP_ID = az monitor action-group list -g $env:AZURE_GROUP_LOGS --query [0].id -o tsv;

            $alertRuleProperties = @{
                severity            = 1
                enabled              = $true
                scopes               = @($env:WEB_TEST_ID, $env:APPLICATION_INSIGHT_ID)
                evaluationFrequency  = "PT1M"
                windowSize           = "PT5M"
                criteria             = @{
                    "odata.type"        = "Microsoft.Azure.Monitor.WebtestLocationAvailabilityCriteria"
                    webTestId           = $env:WEB_TEST_ID
                    componentId         = $env:APPLICATION_INSIGHT_ID
                    failedLocationCount = 2
                }
                actions = @(
                    @{ actionGroupId = $env:ACTION_GROUP_ID }
                )
            }

            $json = $alertRuleProperties | ConvertTo-Json -Depth 10
            [System.IO.File]::WriteAllText("$PWD/alert.json", $json, [System.Text.UTF8Encoding]::new($false))

            az resource create `
                -g $env:AZURE_GROUP_LOGS `
                -n $env:WEB_TEST_ALERT_NAME `
                -l global `
                --resource-type "Microsoft.Insights/metricAlerts" `
                -p '@alert.json';

            if ($LastExitCode -ne 0)
            {
                throw "error";
            }
        }
    }
``` 
