using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShoKanri.Exception.Base;
using ShoKanri.Http;

namespace ShoKanri.API.Filters;

internal class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ProjectException projectException)
        {
            HandleProjectException(context, projectException);
            return;
        }
        ThrowUnknownException(context);
    }

    private static void HandleProjectException(ExceptionContext context, ProjectException exception)
    {
        var errorResponse = new { Errors = exception.GetErrorMessages() };

        context.HttpContext
            .Response.StatusCode = exception.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private static void ThrowUnknownException(ExceptionContext context)
    {
        context.HttpContext
            .Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new { Unknown = context.Exception.Message });
    }
}