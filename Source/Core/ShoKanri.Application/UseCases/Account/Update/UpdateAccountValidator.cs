using FluentValidation;
using ShoKanri.Http.Requests.Account;

namespace ShoKanri.Application.UseCases.Account.Update
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateAccountValidator()
        {
            RuleFor((a) => a.Name).NotEmpty().Length(4, 50)
                .When((a) => a.Name is not null);

            RuleFor((a) => a.Balance).NotEmpty()
                .When((a) => a.Balance is not null);

            RuleFor((a) => a.Description).NotEmpty().MaximumLength(500)
                .When((a) => a.Description is not null);
        }
    }
}