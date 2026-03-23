using Api.Data.Identity.Authentication.External.Direct.Models;
using Api.Data.Identity.Authentication.External.Direct.Models.Criterias;
using Microsoft.Extensions.Logging;
using Nano.App.Api.Controllers;
using Nano.Data.Abstractions;
using Nano.Data.Abstractions.Identity;
using Nano.Data.Abstractions.Identity.Authentication;

namespace Api.Data.Identity.Authentication.External.Direct.Controllers;

/// <inheritdoc />
public class UsersController(ILogger<UsersController> logger, IRepository repository, IIdentityRepository identityRepository, IAuthExternalRepository? authExternalRepository = null)
    : BaseIdentityController<User, UserQueryCriteria>(logger, repository, identityRepository, authExternalRepository);