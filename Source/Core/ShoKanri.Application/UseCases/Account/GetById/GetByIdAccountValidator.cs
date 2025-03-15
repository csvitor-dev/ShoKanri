using FluentValidation;
using ShoKanri.Http.Requests.Account;

namespace ShoKanri.Application.UseCases.Account.Register
{
    public class GetByIdAccountValidator : AbstractValidator<GetByIdAccountRequest>
    {
        public GetByIdAccountValidator()
        {

            RuleFor((a) => a.Id).NotNull().NotEmpty();
        }
    }
}