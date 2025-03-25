using FluentValidation;
using ShoKanri.Http.Requests.Account;

namespace ShoKanri.Application.UseCases.Account.Register
{
    public class RegisterAccountValidator : AbstractValidator<RegisterAccountRequest>
    {
        public RegisterAccountValidator()
        {

            RuleFor((a) => a.Name).NotNull().NotEmpty().Length(4, 50);

            RuleFor((a) => a.InitialBalance).NotNull().NotEmpty();

            RuleFor((a) => a.Description).NotEmpty().MaximumLength(500)
                .When((a) => a.Description is not null);
        }
    }
}