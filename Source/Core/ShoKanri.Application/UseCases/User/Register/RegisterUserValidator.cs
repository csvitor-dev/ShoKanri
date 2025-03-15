using FluentValidation;
using ShoKanri.Http.Requests.User;

namespace ShoKanri.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {

            RuleFor((u) => u.Name).NotNull().NotEmpty().Length(4, 50);

            RuleFor((u) => u.Email).NotNull().NotEmpty().EmailAddress();

            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}