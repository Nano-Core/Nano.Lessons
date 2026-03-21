# Api.Data.Identity.Authentication.Jwt

> _Nano API application with data identity jwt authentication._  
_All lessons are complete, self-contained examples that include build and deployment setup._

> ⚠️ _To run this solution, the **[Nano.Library](https://github.com/Nano-Core/Nano.Library)** repository must be checked out in the same root directory. 
Nano is referenced directly from source (not via NuGet packages) and is expected to be located in the .nano solution folder._

> ⚠️ Remember to set the docker-compose project as startup project, before running the solution in Visual Studio.

***

## Table of Contents
* [Summary](#summary)
* [Configuration](#configuration)

## Summary
This application builds on **[Api.Data.Identity](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Data.MySql)**.     


Add derived controller from `BaseAuthController`

 
- We need entity tests to test authorization. Just a few endpoints
  - Test add or update policy
- Test claims in authorization policy, maybe in the custom auth example




> 📖 Learn more about **[Nano Authentication](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api#authentication)**.

## Configuration
Besides what is already configured from base example, this has beed added.  

```json
"App": {
  "Authentication": {
    "Jwt": {
      "Issuer": null,
      "Audience": null,
      "PublicKey": null,
      "PrivateKey": null,
      "Expiration": "01:00:00",
      "RefreshExpiration": "72:00:00"
    }
  }
}
```

...and for `appesettings.Developmnet.json`.

```json
"App": {
  "Authentication": {
    "Jwt": {
      "Issuer": "nano.development,
      "Audience": "nano.development"
    }
  }
}
```

The same goes for the `appsettings.json` overrides for `Staging` and `Production`. 
For `Staging` and `Production` a secret must also be created for holding the public and private key.  
