# Api.Data.LazyLoading

> _Nano API application with data lazy loading._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**, but any data provider can be used to 
demonstrate repository autosave. Entity controllers have been simplified to showcase autosave; full controllers are unnecessary.   

Once the object graph is created, notice that only `IncludedRelations` appears in the response. Although `Relations` is lazy-loaded in the code, it is not included 
because it lacks the `Include` annotation.  

> 📖 Learn more about **[Nano Data Lazy Loading](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data/README.md#lazy-loading)**.

## Configuration
```json
"Data": {
  "UseLazyLoading": true
}
```
