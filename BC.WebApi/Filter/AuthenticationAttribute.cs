using BC.Utility;
using BC.WebApi.CommonException;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace BC.WebApi.Filter
{
    public class AuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public string Realm { get; set; }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            // Gets the token object of the request
            var authorization = context.Request.Headers.Authorization;

            if (authorization == null)
            {
                return;
            }

            var code = TokenHelper.ValidateToken(authorization.Parameter, out ClaimsIdentity claimsidentity);
            if (code != 200)
            {
                switch (code)
                {
                    case 403: throw new ForbiddenException("The token is expired.");
                    default: throw new UnauthorizedException();
                }
            }

            var principal = new ClaimsPrincipal(claimsidentity);
            if (principal == null)
            {
                throw new UnauthorizedException();
            }

            // Set the principal for authentication
            context.Principal = principal;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
