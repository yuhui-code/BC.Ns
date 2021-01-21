using BC.Ns.Api.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BC.Ns.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
