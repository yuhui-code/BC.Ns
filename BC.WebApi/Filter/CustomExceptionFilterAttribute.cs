using BC.Jwt.CommonException;
using BC.Jwt.Logger;
using BC.Jwt.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace BC.WebApi.Filter
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;

        public CustomExceptionFilterAttribute()
        {
            _logger = new Logger<CustomExceptionFilterAttribute>();
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);

            _logger.Error(actionExecutedContext.Exception);

            HandleExceptionAsync(actionExecutedContext);
            return;
        }

        private void HandleExceptionAsync(HttpActionExecutedContext context)
        {
            // 500 if unexpected
            var code = HttpStatusCode.InternalServerError;
            var errorMessageModel = new ErrorMessageModel()
            {
                MoreInfo = "http:myapi/HelpPage/",
                InternalMessage = context.Exception.ToString()
            };
            if (context.Exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
                errorMessageModel.UserMessage = "NotFound";
                errorMessageModel.CustomErrorCode = "000000";
            }
            else if (context.Exception is UnauthorizedException)
            {
                code = HttpStatusCode.Unauthorized;
                errorMessageModel.UserMessage = "Authorization failed";
                errorMessageModel.CustomErrorCode = "000000";
            }
            else if (context.Exception is BusinessException myException)
            {
                code = HttpStatusCode.PreconditionFailed;
                errorMessageModel.CustomErrorCode = myException.CustomErrorCode;
                errorMessageModel.UserMessage = myException.Message;
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
                errorMessageModel.UserMessage = "An error occurred. Try it again.";
                errorMessageModel.CustomErrorCode = "000000";
            }

            context.Response = new HttpResponseMessage()
            {
                Content = new StringContent(errorMessageModel.UserMessage),
                StatusCode = code
            };

            return;
        }
    }
}
