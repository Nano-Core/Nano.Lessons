# Api.Data.EntityEvents

> _Nano API application with data entity events._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**, but any data provider can be used to 
demonstrate entity events. Additionally, eventing has been enabled mirroring the setup from **[Api.Eventing.RabbityMq](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Eventing.RabbityMq)**,
but any eventing provider can be used. Entity controllers have been simplified to showcase autosave; full controllers are unnecessary.   

We have setup another service in the same solution. Normally, this would be two different solutions, but for demonstrating the entity events in Nano, we need an additional 
applicationb to receive the published entity evnets.

The main application contains models to demonstrate different aspects of entity eventing.  
The `Example` entity contains several foreign key references to `ExampleNavigation`, one required and not part of the publish properties, one nullable and with `NavigationName` 
as part of publish properties, and one included using `Include` attribute. The first shows that when the navigation is not part of the publish properties, the reference won't 
be loaded during add, update and delete. The second shows that when a nullable navigations is `null` then all publish properties from that navigation will be null as well. The last
shows that when an update is issued over nested navigations, that Nano hydrates that.




> 📖 Learn more about **[Nano Data Entity Events](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#entity-events)**.
