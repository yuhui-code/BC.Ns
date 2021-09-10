using BC.Jwt.CommonException;
using BC.Utility;
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

            if(authorization == null)
            {
                return;
            }

            // Call this method to generate the corresponding "ID card holder" according to the token
            var principal = await AuthenticateJwtToken(authorization.Parameter);
            if (principal == null)
            {
                throw new UnauthorizedException();
            }

            // Set the principal for authentication
            context.Principal = principal;
        }

        private async Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            ClaimsIdentity claimsidentity;
            if (!ValidateToken(token, out claimsidentity))
            {
                return await Task.FromResult<IPrincipal>(null);
            }

            // Here is the logic to do after the verification is successful

            // Putting the above ID card in the claims principal is equivalent to giving the ID card to the holder
            return await Task.FromResult(new ClaimsPrincipal(claimsidentity));
        }

        private bool ValidateToken(string token, out ClaimsIdentity claimsidentity)
        {
            claimsidentity = new ClaimsIdentity();

            // Call the custom getprincipal to get the token information object
            var simplePrinciple = TokenHelper.GetPrincipal(token);

            // Get master declaration identity
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null) return false;
            if (!identity.IsAuthenticated) return false;

            claimsidentity = identity;
            return true;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
