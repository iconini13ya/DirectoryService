using Shared;
using System.Text.Json;

namespace DirectoryService.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {

    }
}