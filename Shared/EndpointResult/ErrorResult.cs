using Microsoft.AspNetCore.Http;

namespace Shared.EndpointResult;

public sealed class ErrorResult : IResult
{
    private readonly Error[] _errors;

    public ErrorResult(Error[] errors)
    {
        _errors = errors;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        if (!_errors.Any())
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsJsonAsync(Envelope.Error(_errors));
        }

        var distinctErrorTypes = _errors
            .Select(e => e.Type)
            .Distinct()
            .ToList();

        int statusCode = distinctErrorTypes.Count > 1
            ? StatusCodes.Status500InternalServerError
            : GetStatusCodeFromErrorType(distinctErrorTypes.First());

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json";

        return httpContext.Response.WriteAsJsonAsync(Envelope.Error(_errors));
    }

    private int GetStatusCodeFromErrorType(ErrorType errorType) =>
        errorType switch
        {
            ErrorType.VALIDATION => StatusCodes.Status400BadRequest,
            ErrorType.NOT_FOUND => StatusCodes.Status404NotFound,
            ErrorType.CONFLICT => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };
}
