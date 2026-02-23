# Console.StartupTasks

> _Nano Console application with startup tasks._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the [Nano.Library](https://github.com/Nano-Core/Nano.Library) repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Console.Blank](https://github.com/Nano-Core/Nano.Lessons/tree/master/Console._Blank)**.  

This application demonstrates a waiting worker that delays its execution until all registered startup tasks have completed, 
ensuring that the console application only runs after initialization is finished.  

Run the application and observe how both example workers wait for the startup tasks to complete before executing their logic.  

> 📖 Learn more about **[Nano Startup Tasks](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App#startup-tasks)**.
