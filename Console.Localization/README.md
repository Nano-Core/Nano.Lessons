# Console.Localization

> _Nano Console application with localization configured._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the [Nano.Library](https://github.com/Nano-Core/Nano.Library) repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Console.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Console._Blank)**.  

This application demonstrates configuring `Localization` in a Nano console application.  

Run the application and observe how the configured localization is used when printing out `DateTimeOffset.Now`.  

> 📖 Learn more about **[Nano Console Localization](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Console/README.md#localization)**.

## Configuration
```json
"App": {
  "Localization": {
    "DefaultCulture": "fr-FR"
  }
}
```