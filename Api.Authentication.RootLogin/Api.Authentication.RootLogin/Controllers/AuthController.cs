using System;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.App.Api.Mvc.Authentication.Abstractions;
using Nano.Data.Abstractions.Identity.Authentication;

namespace Api.Authentication.RootLogin.Controllers;

/// <inheritdoc />
public class AuthController(ILogger<AuthController> logger, IIdentityAuthRepository? identityAuthRepository = null, IAuthTransientRepository? authTransientRepository = null, IAuthRootRepository? authRootRepository = null, IAuthExternalRepository? authExternalRepository = null)
    : BaseAuthController<Guid>(logger, identityAuthRepository, authTransientRepository, authRootRepository, authExternalRepository);