# Api.VirusScan

> _Nano API application with virus scanning._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Rememmber to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)

## Summary
This application builds on **[Api.Hosting.Http](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Hosting.Http)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.  
    
Invoke the endpoint. To test virus detection, you can use the EICAR test files 
available here: [https://www.eicar.org/download-anti-malware-testfile](https://www.eicar.org/download-anti-malware-testfile).  

| Endpoint                                        | Description                                                                                                                                 |
| ----------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/virus-scan` | Returns a `200 OK` response if there is no virus in the filem, and otherwise a `500 ERROR` with the found virus name in the error message.  |

> 📖 Learn more about **[Nano Virus Scan](https://github.com/Nano-Core/Nano.Library/Nano.App.Api/README.md#virus-scan)**.

## Configuration
```json
"App": {
  "VirusScan": {
    "Host": "clamav",
    "Port": 3310,
    "HealthCheck": {
      "UnhealthyStatus": "Unhealthy"
    }
  }
}
```

## Docker Compose
Added `ClamAV` dependency to the `docker-compose.yml`

```yaml
services:
  api.virusscan:
    depends_on:
      - clamav

  clamav: 
    image: clamav/clamav
    hostname: clamav
    ports:
      - 3310:3310
    networks:
      - network
```
