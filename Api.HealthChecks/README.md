# Api.HealthChecks

> _Nano API application with health checks._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [GitHub Actions](#gitHub-actions)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  

This example illustrates the use of Nano API health-checks.  

Open [http://localhost:8080/healthz](http://localhost:8080/healthz) to view the startup health-check JSON report.  
Open [http://localhost:8080/healthz-ui](http://localhost:8080/healthz-ui) to view the startup health-check in the web-based UI.  

A webhook is configured for health-check that will trigger if the application becomes unhealthy.  

| Endpoint                                          | Description                                            |
| ------------------------------------------------- | ------------------------------------------------------ |
| `http://localhost:8080/api/examples/health-check` | Returns a `200 OK` response with health-check status.  |
| `http://localhost:8080/api/examples/webhook`      | Returns a `200 OK` response.                           |

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Apihealth-checks)**.

## Configuration

```json
"App": {
  "HealthCheck": {
    "EvaluationInterval": 10,
    "FailureNotificationInterval": 60,
    "MaximumHistoryEntriesPerEndpoint": 50,
    "WebHooks": [
      {
        "Name": "Test",
        "Url": "http://localhost:8080/api/examples/webhook",
        "Payload": null
      }
    ]
  }
}
```

## GitHub Actions

```yaml

  AVAILABILITY_CHECK_FREQUENCY: 300
      - name: Set Environmental Variables
        id: set-variables
        shell: pwsh
        run: |
          if ('${{ github.ref }}' -eq 'refs/heads/master') {
              echo "APPLICATION_INSIGHT_AVAILABILITY_URI=https://${{ secrets.PRODUCTION_HOST }}/healthz" >> $env:GITHUB_ENV;
          }
          else {
              echo "APPLICATION_INSIGHT_AVAILABILITY_URI=https://${{ secrets.STAGING_HOST }}/healthz" >> $env:GITHUB_ENV;
          }



          sudo az extension add -n application-insights;

          $env:SERVICE_NAME_INSIGTHS = $env:SERVICE_NAME + "-insights";
          $env:APPLICATION_INSIGHT_ID = sudo az monitor app-insights component show --query "[?contains(name, '$env:SERVICE_NAME_INSIGTHS')].[id]" -o tsv;
          if ([string]::IsNullOrEmpty($env:APPLICATION_INSIGHT_ID))
          {
              $env:WORKSPACE_ID = sudo az monitor log-analytics workspace list --query "[?contains(name, 'log-analytics')].[id]" -o tsv;

              if (-not [string]::IsNullOrEmpty($env:WORKSPACE_ID))
              {
                  $env:APPLICATION_INSIGHT_ID = sudo az monitor app-insights component create `
                      -a $env:SERVICE_NAME_INSIGTHS `
                      -l $env:AZURE_LOCATION `
                      -g $env:AZURE_GROUP `
                      --workspace $env:WORKSPACE_ID `
                      --query "[id]" -o tsv;

                  if ($LastExitCode -ne 0)
                  { 
                      throw "error";
                  };
              }
          };

          $env:SERVICE_NAME_AVAILABILITY = $env:SERVICE_NAME +'-availability-' + $env:ASPNETCORE_ENVIRONMENT.ToLower();
          $env:APPLICATION_INSIGHT_AVAILABILITY_ID = sudo az monitor app-insights web-test list -g $env:AZURE_GROUP --query "[?contains(name, '$env:SERVICE_NAME_AVAILABILITY')].[id]" -o tsv;
          if ([string]::IsNullOrEmpty($env:APPLICATION_INSIGHT_AVAILABILITY_ID))
          {
              $env:APPLICATION_INSIGHT_HIDDEN_LINK = 'hidden-link:' + $env:APPLICATION_INSIGHT_ID + '=Resource';
              sudo az monitor app-insights web-test create `
                  -n $env:SERVICE_NAME_AVAILABILITY `
                  --defined-web-test-name $env:SERVICE_NAME_AVAILABILITY `
                  -g $env:AZURE_GROUP `
                  -l $env:AZURE_LOCATION `
                  --kind multistep `
                  --web-test-kind standard `
                  --frequency $env:AVAILABILITY_CHECK_FREQUENCY `
                  --enabled true `
                  --retry-enabled true `
                  --ssl-check true `
                  --ssl-lifetime-check 30 `
                  --http-verb GET `
                  --request-url $env:APPLICATION_INSIGHT_AVAILABILITY_URI `
                  --expected-status-code 200 `
                  --content-validation content-match='\"status\":\"unhealthy\"' ignore-case=true pass-if-text-found=false `
                  --tags $env:APPLICATION_INSIGHT_HIDDEN_LINK `
                  --locations Id='us-ca-sjc-azr' `
                  --locations Id='us-va-ash-azr' `
                  --locations Id='emea-gb-db3-azr' `
                  --locations Id='emea-nl-ams-azr' `
                  --locations Id='apac-hk-hkn-azr';
          };
          if ($LastExitCode -ne 0)
          { 
              throw "error";
          };




``` 
