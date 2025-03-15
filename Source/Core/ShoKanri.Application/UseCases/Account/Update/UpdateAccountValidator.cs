using FluentValidation;
using ShoKanri.Http.Requests.Account;

namespace ShoKanri.Application.UseCases.Account.Update
{
    public class UpdateAccountValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateAccountValidator()
        {

            RuleFor((a) => a.Id).NotEmpty().NotNull();

            RuleFor((a) => a.UserId).NotEmpty().NotNull();

            RuleFor((a) => a.Name).NotEmpty().NotNull();

            RuleFor((a) => a.Balance).NotEmpty().NotNull();

            RuleFor((a) => a.Description).NotEmpty().NotNull();


        }
    }
}