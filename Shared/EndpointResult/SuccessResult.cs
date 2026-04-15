using Microsoft.AspNetCore.Http;

namespace Shared.EndpointResult;

public class SuccessResult<TValue> : IResult
{
    public readonly TValue _value;

    public SuccessResult(TValue value)
    {
        _value = value;
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);

        httpContext.Response.StatusCode = StatusCodes.Status200OK;
        httpContext.Response.ContentType = "application/json";

        return httpContext.Response.WriteAsJsonAsync(Envelope<TValue>.Ok(_value));
    }
}
