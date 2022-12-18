using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MockInterview.Core.Exceptions;

namespace MockInterview.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _environment;

    public ExceptionFilter(IHostEnvironment environment)
    {
        _environment = environment;
    }

    public void OnException(ExceptionContext context)
    {
        // Preparing error result and status
        var message = _environment.IsDevelopment() ? context.Exception?.Message + context.Exception?.InnerException?.Message : null;
        var statusCode = context.Exception switch
        {
            ArgumentNullException => 400,
            ArgumentOutOfRangeException => 400,
            ArgumentException => 400,
            EntryNotFoundException => 404,
            InvalidOperationException => 501,
            _ => 400
        };

        var result = new ProblemDetails
        {
            Title = message,
            Status = statusCode
        };

        context.ExceptionHandled = true;
        context.Result = new ObjectResult(result);
    }
}