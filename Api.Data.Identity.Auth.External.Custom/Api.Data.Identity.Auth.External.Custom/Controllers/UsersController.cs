using Api.Data.Identity.Auth.External.Custom.Models;
using Api.Data.Identity.Auth.External.Custom.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;
using Nano.Data.Abstractions.Identity;

namespace Api.Data.Identity.Auth.External.Custom.Controllers;

/// <inheritdoc />
public class UsersController(ILogger<UsersController> logger, IRepository repository, IIdentityRepository identityRepository)
    : BaseIdentityController<User, UserQueryCriteria>(logger, repository, identityRepository);