using Api.Data.Identity.Auth.External.Custom.Models;
using Api.Data.Identity.Auth.External.Custom.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;
using Nano.Data.Abstractions.Identity;
using Nano.Data.Abstractions.Identity.Authentication;

namespace Api.Data.Identity.Auth.External.Custom.Controllers;

/// <inheritdoc />
public class UsersController(ILogger<UsersController> logger, IRepository repository, IIdentityRepository identityRepository, IAuthExternalRepositoryAggregator? authExternalRepository = null)
    : BaseIdentityController<User, UserQueryCriteria>(logger, repository, identityRepository, authExternalRepository);