using FluentValidation;
using ShoKanri.Http.Requests.User;

namespace ShoKanri.Application.UseCases.User.Login;

public class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    public LoginUserValidator()
    {
        RuleFor(user => user.Email).NotNull().NotEmpty().EmailAddress();
        RuleFor(user => user.Password).NotNull().NotEmpty();
    }
}