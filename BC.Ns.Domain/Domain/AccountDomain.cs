using BC.Ns.Domain.Interface;
using BC.Ns.Models.Request;
using BC.WebApi.Logger;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BC.Ns.Domain.Domain
{
    public class AccountDomain : IAccountDomain
    {
        private ILogger<AccountDomain> _logger;

        public AccountDomain(ILogger<AccountDomain> logger)
        {
            _logger = logger;
        }

        public async Task<bool> Login(AccountRequest account)
        {
            var tokenExpiration = TimeSpan.FromDays(14);
            ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, "zzzili"));
            identity.AddClaim(new Claim(ClaimTypes.Sid, "1"));

            var props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
            };

            var ticket = new AuthenticationTicket(identity, props);
            var accessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
            JObject tokenResponse = new JObject(
                                        new JProperty("userName", "zzzili"),
                                        new JProperty("access_token", accessToken),
                                        new JProperty("token_type", "bearer"),
                                        new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                                        new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                                        new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString()));

            return tokenResponse;

            return await Task.FromResult<bool>(true);
        }
    }

    public class GenerateTokenModel
    {
        public GenerateTokenModel()
        {
            Identity = new ClaimsIdentity();
        }

        public ClaimsIdentity Identity { get; set; }

        public string AppCode { get; set; }

        public string JWTKey { get; set; }

        public double ExpiresInSeconds { get; set; }

        //Token颁发机构
        public string ValidIssuer { get; set; }
    }
}
