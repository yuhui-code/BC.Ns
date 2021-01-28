using BC.Ns.Api.App_Start;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BC.Ns.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // 安全协议
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            // Filters 配置
            FilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters);

            // Swagger 配置
            SwaggerConfig.Register(GlobalConfiguration.Configuration);

            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
