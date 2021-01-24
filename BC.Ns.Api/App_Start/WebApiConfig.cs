using BC.Ns.Api.App_Start.Ioc;
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

            // 安全协议
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            // Filters 配置
            FilterConfig.RegisterGlobalFilters(config.Filters);

            // Ioc 配置
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(IoC.Initialize());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 跨域配置
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Swagger 配置
            SwaggerConfig.Register(config);
        }
    }
}
