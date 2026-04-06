using Shared;
using System.Text.Json;

namespace DirectoryService.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {

    }
}
