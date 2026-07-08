# Console.Eventing.RabbitMq

> _Nano console application with rabbitmq eventing._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the [Nano.Library](https://github.com/Nano-Core/Nano.Library) repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)

## Summary
This application builds on **[Console.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Console._Blank)**.

Although event handling is not typically associated with console applications, there are valid scenarios where event-driven architecture makes sense 
in a console worker. For example, a worker might retrieve data from a database or an API client and publish events for distributed processing across services.  

Run the application and observe how an `EventModel` instance is published by the `ExampleWorker` and handled by the `EventingHandler`.

Check the console output for the message: `Testing eventing`.  
This message is written by the `EventHandler` when the event is successfully received.

You can access the RabbitMQ management interface here: **[http://localhost:15672](http://localhost:15672)**. From there, you can monitor the messages 
being published and consumed in real time.

> 📖 Learn more about **[Nano.Eventing.RabbitMq](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Eventing.RabbitMq/README.md#nanoeventingrabbitmq)**.

## Registration
The following eventing provider has been registered using `ConfigureServices(...)` in `Program.cs`.

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
    "Id": "rabbitmq_user",
    "Secret": "password"
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
      RABBITMQ_DEFAULT_VHOST: "/"

```
## Kubernetes
Added the `rabbitmq` secret for password to the `cronjob.yaml`.  

```yaml
spec:
  jobTemplate:
    spec:
      template:
        spec:
          containers:
            env:
              - name: Eventing__Credentials__Host
                valueFrom:
                  secretKeyRef:
                    name: rabbitmq-default-user
                    key: host
              - name: Eventing__Credentials__Port
                valueFrom:
                  secretKeyRef:
                    name: rabbitmq-default-user
                    key: port
              - name: Eventing__Credentials__Id
                valueFrom:
                  secretKeyRef:
                    name: rabbitmq-default-user
                    key: username
              - name: Eventing__Credentials__Secret
                valueFrom:
                  secretKeyRef:
                    name: rabbitmq-default-user
                    key: password
```

> ⚠️ The `rabbitmq` secret is created alongside the **[Nano Azure Kubernetes Eventing](https://github.com/Nano-Core/Nano.Azure.Kubernetes/tree/master/Nano.Azure.Kubernetes.RabbitMQ)** 
