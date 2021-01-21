using BC.WebApi.Filter;
using NLog;
using System;
using System.Web.Http.Filters;

namespace BC.Ns.Api.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}
