using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.App.Api.Mvc.Authentication.Abstractions;
using System;

namespace Api.Authentication.RootLogin.Controllers;

/// <inheritdoc />
public class AuthController(ILogger<AuthController> logger, IAuthRepository authRepository)
    : BaseAuthController<Guid>(logger, authRepository);