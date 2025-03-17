using FluentValidation;
using ShoKanri.Http.Requests.Account;

namespace ShoKanri.Application.UseCases.Account.GetAll
{
    public class GetAllAccountsValidator: AbstractValidator<GetAllAccountsRequest>
    {
        public GetAllAccountsValidator() {
                    
                RuleFor((a) => a.UserId).NotEmpty().NotNull();
        }
    }
}