# Api.Documentation.Csp

> _Nano API application with api documentation and CSP._  
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
This application builds on **[Api.Documenation](https://github.com/Nano-Core/Nano.Lessons/tree/master/Api.Documenation)**.    

This example shows using API documentation with strict CSP security. Run the solution and open [https://localhost:4443/docs](https://localhost:4443/docs) in your browser to 
view the API documentation.  

Also a CSP hash has been added and the policy configured to allow inline styles for swagger.  

| Endpoint                                           | Description          |
| -------------------------------------------------- | -------------------- |
| `http://localhost:8080/api/examples/documentation` | Returns a `200 OK`.  |

> 📖 Learn more about **[Nano API Documentation](https://github.com/Nano-Core/Nano.Library/tree/master/Nano.App.Api/README.md#documentation)**.

## Configuration

```json
"App": {
  "Documentation": {
    "Name": "Application"
  },
  "HttpPolicyHeaders": {
    "Csp": {
      "Scripts": {
        "IsSelf": true
      },
      "Styles": {
        "IsSelf": true,
        "Hashes": [
          "sha256-RL3ie0nH+Lzz2YNqQN83mnU0J1ot4QL7b99vMdIX99w="
        ]
      }
    }
  }
}
```
