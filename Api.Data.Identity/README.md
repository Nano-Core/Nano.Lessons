# Api.Data.Identity

> _Nano API application with data identity._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Data.MySql](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**, but any data provider can be used to 
demonstrate repository autosave. Entity controllers have been simplified to showcase identity; full controllers are unnecessary.   

The `User` entity model, `UserMapping` data mapping, `UserQueryCriteria` query criteria and the `UsersControlller` has been added to the solutiin. The controller is deriving
from the `BaseIdentityContrlller<TEntity, TCriteria>`, epxosing all configured identity actions. Everything needed to expose identity controller actions.  

The application is configured to audit all identity models.  

Also, API documentation has been configured, in order to easier see which audit endpoints are available. It can be accessed 
here: **[http://localhost:8080/docs](http://localhost:8080/docs)**.  

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#documentation)**.  

Not all identity actions are enabled in this example. It demonstrates identity functionality without any authentication enabled. Other lessons cover the different supported 
authentication methods and the corresponding identity actions to manage them.  

> 📖 Learn more about **[Nano Data Identity](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.Data#identity)**.

## Configuration
The data identity has been configured for the application. The `UseAudit` ahs been set to `All` in order to audit log all identity changes. Normally, you would probably be more 
selective in that option and choose some identityt model to audit.  

```json
"Data": {
  "ConnectionString": null,
  "Identity": {
    "TokensExpiration": "24:00:00",
    "UseAudit": "All", 
    "User": {
      "IsUniqueEmailAddressRequired": true,
      "IsUniquePhoneNumberRequired": false,
      "AllowedUserNameCharacters": "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+",
      "DefaultRoles": [
        "administrator"
      ]
    },
    "SignIn": {
      "RequireConfirmedEmail": false,
      "RequireConfirmedPhoneNumber": false
    },
    "Lockout": {
      "AllowedForNewUsers": true,
      "MaxFailedAccessAttempts": 3,
      "DefaultLockoutTimeSpan": "00:30:00"
    },
    "Password": {
      "RequireDigit": true,
      "RequireNonAlphanumeric": true,
      "RequireLowercase": true,
      "RequirUppercase": true,
      "RequiredLength": 12,
      "RequiredUniqueCharacters": 3
    }
  }
}
```
