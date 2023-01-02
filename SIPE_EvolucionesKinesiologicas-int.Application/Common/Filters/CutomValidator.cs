using System.Text;
using System.Net;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Filters;
using SIPE_Evolucion.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SIPE_Evolucion.Application.Common.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;
        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            LogError(context);

            Dictionary<Type, HttpStatusCode> exceptionHttpStatusCodes = new Dictionary<Type, HttpStatusCode>
            {
                { typeof(InvalidUserTokenException), HttpStatusCode.BadRequest }
            };

            IActionResult result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });

            if (context.Exception is Exceptions.ValidationException validationException)
            {
                result = new JsonResult(validationException.Failures);
                code = HttpStatusCode.BadRequest;
            }
            else if (context.Exception is NotFoundException notFounException)
            {
                result = new JsonResult(notFounException.Message);
                code = HttpStatusCode.NotFound;
            }
            else if (exceptionHttpStatusCodes.ContainsKey(context.Exception.GetType()))
            {
                code = exceptionHttpStatusCodes[context.Exception.GetType()];
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = result;
        }

        private void LogError(ExceptionContext context)
        {
            var sb = new StringBuilder();
            sb.Append(BuildRequestInfo(context));
            sb.Append(BuildExceptionMessage(context.Exception));
            _logger.LogError(sb.ToString());

        }

        private string BuildRequestInfo(ExceptionContext context)
        {
            var sb = new StringBuilder();
            if (context.ActionDescriptor.RouteValues.ContainsKey("controller") &&
               context.ActionDescriptor.RouteValues.ContainsKey("action"))
            {
                sb.Append($"Error en {context.ActionDescriptor.RouteValues["controller"]}/{context.ActionDescriptor.RouteValues["action"]}\n");
            }
            if (context.HttpContext.Request.Method == "GET")
            {
                sb.Append($"QueryString: {context.HttpContext.Request.QueryString}\n");

            }
            else
            {
                using (StreamReader stream = new StreamReader(context.HttpContext.Request.Body))
                {
                    sb.Append($"Body: {stream.ReadToEnd()}\n");
                }
            }
            return sb.ToString();
        }

        private string BuildExceptionMessage(Exception exception)
        {
            var sb = new StringBuilder();
            sb.Append($"Mensaje: {exception.Message}\n");
            sb.Append($"StackTrace: {exception.StackTrace}\n");
            if (exception.InnerException != null)
            {
                sb.Append(BuildExceptionMessage(exception.InnerException));
            }
            return sb.ToString();
        }
    }
}

