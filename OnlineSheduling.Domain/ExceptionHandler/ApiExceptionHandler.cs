using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace OnlineScheduling.Domain.ExceptionHandler;

public class ApiExceptionHandler(IWebHostEnvironment webHostEnvironment) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var details = new ProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Server error",
            Instance = httpContext.Request.Path.Value,
            Detail = exception.Message,
        };
        
        if (webHostEnvironment.IsDevelopment())
            details.Detail += $"{(exception.InnerException is not null ? $" | {exception.InnerException}" : "")} : {exception.StackTrace}";
        
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        
        await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);
        
        return true;
    }
}