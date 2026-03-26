using System.Threading;
using System.Threading.Tasks;
using Nano.App.Api.Mvc.Authentication;
using Nano.Data.Abstractions.Identity.Authentication.Models;

namespace Api.Data.Identity.Auth.External.Custom.Authentication;

/// <inheritdoc />
public class ExternalProviderCustomRepository : BaseAuthExternalRepository<ExternalProviderCustom>
{
    /// <inheritdoc />
    public override async Task<ExternalAuthenticationData> AuthenticateAsync(ExternalProviderCustom provider, ImplicitFlow implicitFlow, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return new ExternalAuthenticationData
        {
            Id = "external-id",
            Username = "MyUser",
            EmailAddress = "johndoe@domain.com",
            PhoneNumber = "+4520111112",
            Name = "John Doe",
            ExternalToken =
            {
                Name = this.ProviderName,
                Token = "token",
                RefreshToken = "refresh-token"
            }
        };
    }

    /// <inheritdoc />
    public override async Task<ExternalAuthenticationData> AuthenticateAsync(ExternalProviderCustom provider, AuthCodeFlow authCodeFlow, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return new ExternalAuthenticationData();
    }

    /// <inheritdoc />
    public override async Task<ExternalAuthenticationToken> AuthenticateRefreshAsync(ExternalProviderCustom provider, string refreshToken, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return new ExternalAuthenticationToken();
    }
}