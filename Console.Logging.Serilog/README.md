# Console.Logging.Serilog

> _Nano Console application with Serilog logging._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the [Nano.Library](https://github.com/Nano-Core/Nano.Library) repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)

## Summary
This application builds on **[Console.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Console._Blank)**.  

This application demonstrates logging with Serilog for a console application.  

Run the application and observe how `ExampleWorker` logs a warning to the console. Also note the `LogLevelOverrides` configuration, 
where logs under the `Microsoft` namespace are set to `Warning`, which suppresses several informational messages during application startup.  

> 📖 Learn more about **[Nano.Logging.Serilog](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Logging.Serilog)**.

## Registration
The following logging has been registered using `ConfigureServices(...)` in `program.cs`.  

```csharp
...
.ConfigureServices(services =>
{
    services
        .AddNanoLogging<SerilogProvider>();
})
...
```

## Configuration
Configured the application with the necessary logging setup.  

```json
"Logging": {
  "LogLevel": "Information",
  "LogLevelOverrides": [
    {
      "Namespace": "Microsoft",
      "LogLevel": "Warning"
    }
  ]
}
```
