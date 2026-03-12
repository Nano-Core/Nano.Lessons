# Api.Data.MySql.Mappings

> _Nano API application with mysql advanced data mappings._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**. Entity controllers have been 
simplified to showcase setting mysql views; full controllers are unnecessary.  

Added `Profile` and nesetd classes for mapping owned types and nested owned types. 
Added two properties on `Example` for `Profile` model, one that will be mapped as owned type and one for mapping the enture object hierachy serialzied to JSON and 
added to a simple string column.  

Also, a normalized (capitalized) property of `Example.Name` has been added - `Example.NameNormalized`. The query critiera is now using that property, and 
calling `.ToUpper()`on the criteria value before building the linq expression.  

Last, a unique index has been added to `Example.NameNormalized`. Observe how Nano renames the index prefixing with 'UX_'.  

> 📖 Learn more about **[Nano.Data.MySql](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data.MySql)**.
