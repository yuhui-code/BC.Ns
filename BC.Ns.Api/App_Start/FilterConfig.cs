﻿using BC.WebApi.Filter;
using System.Web;
using System.Web.Mvc;

namespace BC.Ns.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}
