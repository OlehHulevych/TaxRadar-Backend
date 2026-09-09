using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaxRadar_Application.Exceptions;

namespace TaxRadar_backned.Hanlders;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    : IExceptionHandler
{
  


    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled error occured");
        httpContext.Response.StatusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status422UnprocessableEntity,
            ForbiddenAccessException => StatusCodes.Status403Forbidden,
            BadRequestException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError


        };
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Type = exception.GetType().Name,
            Title = "An error occured",
            Detail = exception.Message
        });
        return true;
    }
}