using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nano.Data.Abstractions.Identity.Consts;

namespace Api.Data.Identity.Authentication.External.Direct.Authentication;

/// <summary>
/// 
/// </summary>
public class AlwaysSuccessAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    internal const string SCHEME_NAME = "AlwaysSuccess";

    /// <inheritdoc />
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "User"),
            new Claim(ClaimTypes.NameIdentifier, "user"),
            new Claim(ClaimTypes.Role, BuiltInUserRoles.ADMINISTRATOR)
        };

        var identity = new ClaimsIdentity(claims, SCHEME_NAME);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, SCHEME_NAME);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}