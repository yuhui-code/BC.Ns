using BC.Utility;
using System.Security.Claims;
using System.Web.Http.Controllers;

namespace BC.WebApi.Filter
{
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Gets the token object of the request
            var authorization = actionContext.Request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer" || string.IsNullOrEmpty(authorization.Parameter))
            {
                return false;
            }

            // Call this method to generate the corresponding "ID card holder" according to the token
            var principal = ValidateToken(authorization.Parameter);
            if (!principal)
            {
                return false;
            }

            return true;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }

        private bool ValidateToken(string token)
        {
            // Call the custom getprincipal to get the token information object
            var simplePrinciple = TokenHelper.GetPrincipal(token);

            // Get master declaration identity
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null) return false;
            if (!identity.IsAuthenticated) return false;

            return true;
        }
    }
}
