# Api.Data.SqlServer.Spatial

> _Nano API application with sql server spatial data._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Registration](#registration)
* [Configuration](#configuration)
* [Docker-compose](#docker-compose)
* [Kubernetes](#kubernetes)
* [GitHub Actions](#github-actions)

## Summary
This application builds on **[Api.Data.SqlServer](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.SqlServer)**.  





> 📖 Learn more about **[Nano.Data.SqlServer](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.SqlServer)**.



MUST CREATE SPATIAL INDEX MANUALLY
ALSO WRITE THIS IN THE Nano.Data.SqlServer readme


            migrationBuilder.Sql("""
                                 CREATE SPATIAL INDEX IX_Example_Point
                                 ON Example(Point)
                                 USING GEOGRAPHY_GRID
                                 """);