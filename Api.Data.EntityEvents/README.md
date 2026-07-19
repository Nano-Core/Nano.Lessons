# Api.Data.EntityEvents

> _Nano API application with data entity events._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

> 💡 Explore API requests for this lesson in our **[Public Nano Workspace on Postman](https://www.postman.com/nanocore/nano-core/collection/g2z9po5/nano-lessons)**.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/blob/master/Api.Data.MySql)**, but any data provider can be used to 
demonstrate entity events. Additionally, eventing has been enabled mirroring the setup from **[Api.Eventing.RabbityMq](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Eventing.RabbitMq)**,
but any eventing provider can be used. New entity controllers have been added for use with showcasing entity events.  

An additional application has been added to the solution. In a typical architecture, this application would be placed in a separate solution. However, for the purpose of demonstrating 
entity events in Nano, it has been included within the same solution. This setup allows the second application to receive and handle the published entity events from the first application, 
enabling a complete end-to-end event flow for demonstration purposes.  

A set of entities has been introduced to demonstrate the eventing behavior. The core structure consists of a `Customer` entity that derives from `Person`. A `Customer` contains 
a `Profile`, which in turn contains an `Address`. In addition, the `Customer` has a collection of `Order` entities, and the `Profile` includes an owned navigation property. The full 
entity relationships can be inspected directly in the codebase.  

Also an `OnInserting` and `OnUpdating` trigger has been mapped for `Customer`, to show how the entity events will get the updated value.  

> 📖 Learn more about **[Nano Data Triggers](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data/README.md#triggers)**.

Both `Person` and `Customer` are annotated with the `PublishAttribute`, and define property names that determine which fields should trigger publish events on added, modified, 
and deleted actions. Several controllers have also been added to support these entities, enabling various create, update, and delete operations to trigger `Customer` entity events. When 
a `Customer` is added, modified, or deleted directly, an event is published. However, changes to dependent navigation properties will also result in a `Modified` event being published 
for the `Customer`.  

It is also important to note that `Customer` inherits publishable property definitions from `Person`. To ensure all property names defined across the entire inheritance hierarchy are 
included, Nano aggregates the `PublishAttribute` metadata and hydrates entities both forward (for direct changes) and in reverse (via foreign key relationships) to capture deferred changes.

> 📖 Learn more about **[Nano Data Entity Events](https://github.com/Nano-Core/Nano.Library/blob/master/Nano.Data/README.md#entity-events)**.
