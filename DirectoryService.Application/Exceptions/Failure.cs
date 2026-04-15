using System.Text.Json;
using Shared;

namespace DirectoryService.Application.Exceptions;

public class Failure : Exception
{
    public Failure(Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {

    }
}
