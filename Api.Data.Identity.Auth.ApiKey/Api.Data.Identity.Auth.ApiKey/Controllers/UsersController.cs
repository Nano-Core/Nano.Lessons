using Api.Data.Identity.Auth.ApiKey.Models;
using Api.Data.Identity.Auth.ApiKey.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;
using Nano.Data.Abstractions.Identity;

namespace Api.Data.Identity.Auth.ApiKey.Controllers;

/// <inheritdoc />
public class UsersController(ILogger<UsersController> logger, IRepository repository, IIdentityRepository identityRepository)
    : BaseEntityUserController<User, UserQueryCriteria>(logger, repository, identityRepository);