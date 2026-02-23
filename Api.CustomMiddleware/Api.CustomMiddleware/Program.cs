using Microsoft.AspNetCore.Builder;
using Nano.App.Api;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(_ =>
    {
        // Blank
    })
    .Build(x =>
    {
        x.Use((context, next) =>
        {
            context.Response.Headers["CustomMiddleware"] = "awesome";

            return next();
        });
    })
    .Run();