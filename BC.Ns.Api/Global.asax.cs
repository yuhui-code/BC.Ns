using BC.Ns.Api.App_Start;
using System.Net;
using System.Web;
using System.Web.Http;

namespace BC.Ns.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // ��ȫЭ��
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            // Filters ����
            FilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters);

            // Swagger ����
            SwaggerConfig.Register(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
