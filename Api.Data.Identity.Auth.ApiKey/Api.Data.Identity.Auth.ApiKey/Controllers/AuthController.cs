using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.App.Api.Mvc.Authentication.Abstractions;

namespace Api.Data.Identity.Auth.ApiKey.Controllers;

/// <inheritdoc />
public class AuthController(ILogger<AuthController> logger, IAuthRepository authRepository)
    : BaseAuthController(logger, authRepository);