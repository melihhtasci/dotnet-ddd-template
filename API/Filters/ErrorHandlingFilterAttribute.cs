using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails
            { 
                Detail = exception.Message,
                Title = "An error occured while process is running",
                Status = (int?)HttpStatusCode.InternalServerError,
                Instance = context.HttpContext.Request.Path
            };

            context.Result = new ObjectResult(problemDetails) { StatusCode = 500 };
            context.ExceptionHandled = true;

            base.OnException(context);
        }
    }
}
