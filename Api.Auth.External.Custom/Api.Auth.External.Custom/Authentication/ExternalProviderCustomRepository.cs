using System.Threading;
using System.Threading.Tasks;
using Nano.App.Api.Mvc.Authentication;
using Nano.Data.Abstractions.Identity.Authentication.Models;

namespace Api.Auth.External.Custom.Authentication;

/// <inheritdoc />
public class ExternalProviderCustomRepository() : BaseAuthExternalRepository<ImplicitFlow>("Custom")
{
    /// <inheritdoc />
    public override async Task<ExternalAuthenticationData> AuthenticateAsync(ImplicitFlow flow, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return new ExternalAuthenticationData
        {
            Id = "external-id",
            Username = "MyUser",
            EmailAddress = "johndoe@domain.com",
            PhoneNumber = "+4520111112",
            Name = "John Doe",
            ExternalToken = new ExternalAuthenticationToken
            {
                Name = this.ProviderName,
                Token = "token",
                RefreshToken = "refresh-token"
            }
        };
    }

    /// <inheritdoc />
    public override async Task<ExternalAuthenticationToken> AuthenticateRefreshAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        return new ExternalAuthenticationToken
        {
            Name = this.ProviderName,
            Token = "token",
            RefreshToken = "refresh-token"
        };
    }
}