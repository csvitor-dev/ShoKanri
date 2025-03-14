using FluentValidation;
using ShoKanri.Http.Requests.Transaction;

namespace ShoKanri.Application.UseCases.Transactions.Income.GetAll
{
    public class GetAllIncomesValidator: AbstractValidator<GetAllTransactionRequest>
    {
        public GetAllIncomesValidator() {
            
            RuleFor((e) => e.AccountId).NotEmpty().NotNull();

        }
    }
}