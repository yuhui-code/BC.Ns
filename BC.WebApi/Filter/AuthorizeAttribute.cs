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

            var code = TokenHelper.ValidateToken(authorization.Parameter, out ClaimsIdentity claimsidentity);
            if (code != 200)
            {
                return false;
            }

            return true;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }
    }
}
