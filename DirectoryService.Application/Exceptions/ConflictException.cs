using System.Text.Json;
using Shared;

namespace DirectoryService.Application.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {

    }
}
