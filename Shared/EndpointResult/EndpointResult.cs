using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;

namespace Shared.EndpointResult;

public sealed class EndpointResult<TValue> : Microsoft.AspNetCore.Http.IResult
{
    private readonly Microsoft.AspNetCore.Http.IResult _result;

    public EndpointResult(Result<TValue, Error[]> result)
    {
        _result = result.IsSuccess
            ? new SuccessResult<TValue>(result.Value)
            : new ErrorResult(result.Error);
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        return _result.ExecuteAsync(httpContext);
    }

    public static implicit operator EndpointResult<TValue>(Result<TValue, Error[]> result) => new(result);
}
