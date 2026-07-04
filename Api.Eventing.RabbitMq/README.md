# Api.Eventing.RabbitMq

> _Nano API application with rabbitmq eventing._  
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

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.

While it is uncommon for the same application to both publish and consume an event, this pattern is used here for demonstration purposes. 
In real-world scenarios, one service typically publishes events while other services consume them. For simplicity, this example combines both roles in a single service.  

Run the endpoints and observe an `EventModel` instance being published and handled in the `EventingHandler`. Check the console output for 
the message: `Testing eventing` or `Event Routed: Testing eventing`, depending on the endpoint. This message is written by the `EventingHandler` when the 
event is received.

You can also monitor the messages via the RabbitMQ management interface: **[http://localhost:15672](http://localhost:15672)**

An eventing health check is configured to target the RabbitMQ.  
Open **[http://localhost:8080/healthz](http://localhost:8080/healthz)** to view the health-check status in the JSON response.

> 📖 Learn more about **[Nano Health Checks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#health-checks)**

The following endpoint is available for testing:

| Endpoint                                                   | Description                                                                                                              |
| ---------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| `http://localhost:8080/api/examples/eventing`              | Returns a simple `200 OK` response. Publishes a message that wiil be consumed by the `EventHandler`                      |
| `http://localhost:8080/api/examples/eventing-routing-key`  | Returns a simple `200 OK` response. Publishes a message using routing key that wiil be consumed by the `EventHandler`    |

> 📖 Learn more about **[Nano.Eventing.RabbitMq](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Eventing.RabbitMq/README.md#nanoeventingrabbitmq)**.

## Registration
The following eventing provider has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(services =>
{
    services
        .AddNanoEventing<RabbitMqProvider>();
})
...
```

## Configuration
Configured the application `appsettings.json` with the necessary eventing setup.  

```json
"Eventing": {
  "Host": "rabbitmq",
  "VHost": "/",
  "Port": 5672,
  "UseSsl": false,
  "Timeout": "00:00:30",
  "Heartbeat": 60,
  "PrefetchCount": 50,
  "Credentials": {
      "Id": null,
      "Secret": null
  },
  "HealthCheck": {
    "UnhealthyStatus": "Unhealthy"
  }
}
```

...and the `appsettings.Development.json` eventing configuration.  

```json
"Eventing": {
  "Credentials": {
    "Id": "rabbitmq_user",
    "Secret": "password"
  }
}
```

Additionally, application health-checks have been enabled with the configuration.  

```json
"App": {
  "HealthCheck": {
  }
}
```

## Docker Compose
Added RabbitMQ as a service dependency in `docker-compose.yml`.  

```yaml
services:
  api.eventing.rabbitmq:
    depends_on:
      - eventing

  eventing: 
    image: rabbitmq:management
    hostname: rabbitmq
    ports:
      - 5671:5671
      - 5672:5672
      - 15671:15671
      - 15672:15672
    networks:
      - network
    environment: 
      RABBITMQ_DEFAULT_USER: rabbitmq_user
      RABBITMQ_DEFAULT_PASS: password
      RABBITMQ_DEFAULT_VHOST: /

```
## Kubernetes
Added the `rabbitmq` secret for password to the `deployment.yaml`.  

```yaml
spec:
  template:
    spec:
      containers:
        env:
        - name: Eventing__Credentials__Id
          valueFrom:
            secretKeyRef:
              name: rabbitmq-auth
              key: username
           envFrom:
        - name: Eventing__Credentials__Secret
          valueFrom:
            secretKeyRef:
              name: rabbitmq-auth
              key: password
```

> ⚠️ The `rabbitmq` secret is created alongside the **[Nano Azure Kubernetes Eventing](https://github.com/Nano-Core/Nano.Azure.Kubernetes/tree/master/Nano.Azure.Kubernetes.RabbitMQ)** 
