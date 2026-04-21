# Api.CustomConfigSection

> _Nano API application with a custom configuration section._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Rememmber to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)
* [Registration](#registration)

## Summary
This application builds on **[Api.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api._Blank)** and adds a simple test controller 
that inherits from the top-level Nano `BaseController`.

This example illustrates how custom configuration sections can be effortlessly registered within a Nano application.  

The following endpoint is available for testing.  

| Endpoint                                                    | Description                                                                |
| ----------------------------------------------------------- | -------------------------------------------------------------------------- |
| `http://localhost:8080/api/examples/custom-config-section`  | Returns a simple `200 OK` response with the custom configuration value.    |

> 📖 Learn more about **[Nano Custom Configuration Sections](https://github.com/Nano-Core/Nano.Library/Nano.App.Api/README.md#custom-configuration-section)**.

## Configuration
A custom configuration section has been added to `appsettings.json`: 

```json
"Custom": {
  "Value": "custom-value"
}
```

## Registration
An option class matching the structure of the configuration has been implemented.  

```csharp
public class CustomOptions
{
    internal static string SectionName => "Custom";

    [Required]
    public virtual string Value { get; set; } = null!;
}
```

Finally, the options model has been registered with the section in startup, as shown below.  

```csharp
...
.ConfigureServices(x =>
{
    x.AddNanoConfigSection<CustomOptions>(CustomOptions.SectionName, out _);
})
...
```
