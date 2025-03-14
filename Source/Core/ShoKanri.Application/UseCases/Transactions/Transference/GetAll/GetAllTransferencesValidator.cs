using FluentValidation;
using ShoKanri.Http.Requests.Transaction.Transference;

namespace ShoKanri.Application.UseCases.Transactions.Transference.GetAll
{
    public class GetAllTransferencesValidator: AbstractValidator<GetAllTransferencesRequest>
    {
        public GetAllTransferencesValidator() {
                        
            RuleFor((e) => e.AccountId).NotEmpty().NotNull();

        }
    }
}