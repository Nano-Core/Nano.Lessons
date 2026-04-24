using System;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.App.Api.Mvc.Authentication.Abstractions;

namespace Api.Auth.External.Custom.Controllers;

/// <inheritdoc />
public class AuthController(ILogger<AuthController> logger, IAuthRepository authRepository)
    : BaseAuthController<Guid>(logger, authRepository);