using System;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace BC.WebApi.Filter
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute, System.Web.Mvc.IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            throw new NotImplementedException();
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);

            actionExecutedContext.Response = new HttpResponseMessage() { Content = new StringContent("error") };
            return;
        }
    }
}
