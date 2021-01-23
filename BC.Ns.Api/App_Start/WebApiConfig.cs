using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BC.Ns.Api.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // 跨域配置
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Filters 配置
            FilterConfig.RegisterGlobalFilters(config.Filters);

            // Swagger 配置
            SwaggerConfig.Register(config);

            // 安全协议
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
