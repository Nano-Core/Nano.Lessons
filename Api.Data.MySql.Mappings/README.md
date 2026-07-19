# Api.Data.MySql.Mappings

> _Nano API application with mysql advanced data mappings._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.Data.MySql)**. Entity controllers have been 
simplified to showcase setting mysql views; full controllers are unnecessary.  

Three new entity models have been added, each demonstrating different types of advanced mappings. The first, `ExampleJson`, shows how to store a complex object in a 
text column: it is serialized when added or updated in the database and deserialized when retrieved, mapping back into the complex object. The second, `ExampleOwned`, 
also has a `Profile` reference like `ExampleJson`, but the complex object is stored as **owned entities** within the same table. The third, `ExampleNormalized`, 
demonstrates property normalization for querying: `FirstName` and `LastName` are concatenated into `FullName`, and an uppercase version, `FullNameNormalized`, is 
used for case-insensitive searches, with the LINQ query calling `.ToUpper()` on the search value to match the normalized property efficiently.  

Last, a unique index has also been added to `Example.NameNormalized`. Observe how Nano renames the index prefixing with 'UX_'.  

> 📖 Learn more about **[Nano.Data.MySql](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data.MySql/README.md#nanodatamysql)**.
