using Api.Data.Identity.Authentication.External.Direct.Authentication;
using Api.Data.Identity.Authentication.External.Direct.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Nano.App.Api;
using Nano.Data.Extensions;
using Nano.Data.MySql;

NanoApiApplication
    .ConfigureApp()
    .ConfigureServices(x =>
    {
        x.AddNanoData<MySqlProvider, MySqlDbContext>();

        x.AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, AlwaysSuccessAuthenticationHandler>(AlwaysSuccessAuthenticationHandler.SCHEME_NAME, AlwaysSuccessAuthenticationHandler.SCHEME_NAME, _ => { });
    })
    .Build()
    .Run();
