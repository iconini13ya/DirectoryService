using Shared;
using FluentValidation.Results;

namespace DirectoryService.Application.Extensions;

public static class ValidationExtension
{
    public static Error[] ToErrors(this ValidationResult validationResult) =>
        validationResult.Errors.Select(e => Error.Validation(e.ErrorCode, e.ErrorMessage, e.PropertyName)).ToArray();
}
