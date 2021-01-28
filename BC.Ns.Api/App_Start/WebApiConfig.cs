using BC.Ioc;
using System.Web.Http;

namespace BC.Ns.Api.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

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
        }
    }
}
