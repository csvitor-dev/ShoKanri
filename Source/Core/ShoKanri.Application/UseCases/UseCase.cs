using FluentValidation;
using ShoKanri.Exception.Project;

namespace ShoKanri.Application.UseCases;

public class UseCase<T>(AbstractValidator<T> validator)
{
    protected async Task ValidateAsync(T request)
    {
        var result = await validator.ValidateAsync(request);

        var message = await ApplyExtraValidationAsync(request);

        if (result.IsValid && string.IsNullOrEmpty(message))
            return;
        var errorMessages = (from errors in result.Errors select errors.ErrorMessage).ToList();

        if (string.IsNullOrEmpty(message) is false)
            errorMessages.Add(message);

        throw new ErrorOnValidationException(errorMessages);
    }

    protected virtual async Task<string> ApplyExtraValidationAsync(T request)
        => await Task.FromResult(string.Empty);
}