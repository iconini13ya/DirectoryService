using DirectoryService.Application.Exceptions;
using Shared;
using System.Text.Json;

namespace DirectoryService.Middlewares;
#pragma warning disable CA1515 // Consider making public types internal
public class ExceptionMiddleware
#pragma warning restore CA1515 // Consider making public types internal
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
#pragma warning disable CA1031 // Do not catch general exception types
        try
        {
            await _next(context).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            await HandleExceptionAsync(context, ex).ConfigureAwait(false);
#pragma warning restore CA1062 // Validate arguments of public methods
        }
#pragma warning restore CA1031 // Do not catch general exception types
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
#pragma warning disable CA2254 // Template should be a static expression
        _logger.LogError(ex, ex.Message);
#pragma warning restore CA2254 // Template should be a static expression
#pragma warning restore CA1848 // Use the LoggerMessage delegates

        (int code, Error[]? errors) = ex switch
        {
            NotFoundException => (StatusCodes.Status404NotFound, JsonSerializer.Deserialize<Error[]>(ex.Message)),
            Failure => (StatusCodes.Status500InternalServerError, JsonSerializer.Deserialize<Error[]>(ex.Message)),
            _ => (StatusCodes.Status500InternalServerError, JsonSerializer.Deserialize<Error[]>(ex.Message))
        };

        context.Response.StatusCode = code;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(errors).ConfigureAwait(false);
    }
}

#pragma warning disable CA1515 // Consider making public types internal
public static class ExceptionMiddlewareExtension
#pragma warning restore CA1515 // Consider making public types internal
{
    public static IApplicationBuilder UseExtensionMiddleware(this WebApplication app) => app.UseMiddleware<ExceptionMiddleware>(); 
    
}